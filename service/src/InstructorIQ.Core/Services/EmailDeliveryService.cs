using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Utility;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace InstructorIQ.Core.Services
{
    public class EmailDeliveryService : IEmailDeliveryService
    {
        private readonly InstructorIQContext _context;
        private readonly IOptions<SmtpConfiguration> _smtpOptions;
        private readonly ILogger<EmailDeliveryService> _logger;

        public EmailDeliveryService(
            IOptions<SmtpConfiguration> smtpOptions,
            InstructorIQContext context,
            ILogger<EmailDeliveryService> logger)
        {
            _smtpOptions = smtpOptions;
            _context = context;
            _logger = logger;
        }


        public async Task ProcessEmailQueueAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            _logger.LogTrace("Processing email queue");

            // Get first
            var emailDelivery = await _context.EmailDeliveries
                .FromSql("[IQ].[GetNextEmailDelivery]")
                .FirstOrDefaultAsync(cancellationToken);

            while (emailDelivery != null)
            {
                await ProcessEmail(emailDelivery, cancellationToken).ConfigureAwait(false);

                emailDelivery = await _context.EmailDeliveries
                    .FromSql("[IQ].[GetNextEmailDelivery]")
                    .FirstOrDefaultAsync(cancellationToken);
            }
        }

        public async Task<SmtpResult> SendAsync(MimeMessage mimeMessage, CancellationToken cancellationToken)
        {
            var result = new SmtpResult();

            var settings = _smtpOptions.Value;
            var disposableBag = new DisposableBag();
            var logStream = disposableBag.Create<MemoryStream>();

            var host = settings.Host;
            var port = settings.Port;
            var useSsl = settings.UseSSL;

            var userName = settings.UserName;
            var password = settings.Password;

            try
            {
                // make sure there is a from address
                if (mimeMessage.From.Count == 0)
                    mimeMessage.From.Add(new MailboxAddress(settings.FromAddress));

                var logger = disposableBag.Create(() => new ProtocolLogger(logStream));
                var client = disposableBag.Create(() => new SmtpClient(logger));

                // accept all SSL certificates
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(host, port, useSsl, cancellationToken).ConfigureAwait(false);

                // fix gmail issues
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                if (userName.HasValue() || password.HasValue())
                    await client.AuthenticateAsync(userName, password, cancellationToken).ConfigureAwait(false);

                await client.SendAsync(mimeMessage, cancellationToken).ConfigureAwait(false);
                await client.DisconnectAsync(true, cancellationToken).ConfigureAwait(false);

                result.Successful = true;
            }
            catch (Exception ex)
            {
                result.Successful = false;
                result.Exception = ex;
            }
            finally
            {
                logStream.Position = 0;

                var reader = disposableBag.Create(() => new StreamReader(logStream));

                result.SmtpLog = await reader
                    .ReadToEndAsync()
                    .ConfigureAwait(false);


                disposableBag.Dispose();

                LogResult(mimeMessage, result, host);
            }

            return result;
        }


        private async Task ProcessEmail(EmailDelivery emailDelivery, CancellationToken cancellationToken)
        {
            if (emailDelivery == null)
                return;

            try
            {
                var toAddresses = emailDelivery.To;
                var subject = emailDelivery.Subject.Truncate(20);

                _logger.LogDebug("Processing email To: '{toAddresses}'; Subject: '{subject}'", toAddresses, subject);

                emailDelivery.NextAttempt = GetNextAttemptDate(emailDelivery.Attempts);
                emailDelivery.LastAttempt = DateTimeOffset.UtcNow;
                emailDelivery.Attempts++;
                emailDelivery.Updated = DateTimeOffset.UtcNow;

                // prevent others from processing
                await _context.SaveChangesAsync(cancellationToken);

                var mimeMessage = await LoadMessage(emailDelivery, cancellationToken);
                var smtpResult = await SendAsync(mimeMessage, cancellationToken).ConfigureAwait(false);

                emailDelivery.IsDelivered = smtpResult.Successful;
                emailDelivery.SmtpLog = smtpResult.SmtpLog;
                emailDelivery.Error = smtpResult.Exception?.ToString();

                if (smtpResult.Successful)
                {
                    emailDelivery.Delivered = DateTime.UtcNow;
                    emailDelivery.NextAttempt = null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email: {message}", ex.Message);
                emailDelivery.Error = ex.ToString();
            }

            // save result;
            emailDelivery.Updated = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task<MimeMessage> LoadMessage(EmailDelivery emailDelivery, CancellationToken cancellationToken)
        {
            MimeMessage mimeMessage;

            using (var memoryStream = new MemoryStream(emailDelivery.MimeMessage, 0, emailDelivery.MimeMessage.Length))
            {
                memoryStream.Position = 0;
                mimeMessage = await MimeMessage.LoadAsync(memoryStream, cancellationToken);
            }

            return mimeMessage;
        }

        private void LogResult(MimeMessage mimeMessage, SmtpResult result, string host)
        {
            var status = result.Successful ? "Sent" : "Error sending";
            var to = mimeMessage.To.ToString();
            var subject = mimeMessage.Subject.Truncate(20);
            var message = "{status} email to '{mimeMessage.To}' with subject '{subject}' using Host '{host}'";

            if (result.Successful)
                _logger.LogDebug(message, status, to, subject, host);
            else
                _logger.LogError(result.Exception, message, status, to, subject, host);

        }

        private DateTime? GetNextAttemptDate(int attempts)
        {
            // retry weight, 1 = 1 min, 2 = 30 min, 3 = 2 hrs, 4+ = 8 hrs, 5+ = none
            if (attempts > 5)
                return null;

            if (attempts > 3)
                return DateTime.UtcNow.AddHours(8);

            if (attempts == 3)
                return DateTime.UtcNow.AddHours(2);

            if (attempts == 2)
                return DateTime.UtcNow.AddMinutes(30);

            // default
            return DateTime.UtcNow.AddMinutes(5);
        }

    }
}
