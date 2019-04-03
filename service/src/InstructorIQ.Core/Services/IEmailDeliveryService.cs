using System;
using System.Threading;
using System.Threading.Tasks;
using MimeKit;

namespace InstructorIQ.Core.Services
{
    public interface IEmailDeliveryService
    {
        Task ProcessEmailQueueAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<SmtpResult> SendAsync(MimeMessage mimeMessage, CancellationToken cancellationToken);
    }
}