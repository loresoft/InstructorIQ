using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.User.Commands;
using InstructorIQ.Core.Domain.User.Models;
using InstructorIQ.Core.Options;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InstructorIQ.Core.Domain.User.Handlers
{
    public class UserForgotPasswordCommandHandler : RequestHandlerBase<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>
    {
        private readonly InstructorIQContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IOptions<HostingConfiguration> _hostingOptions;


        public UserForgotPasswordCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IPasswordHasher passwordHasher, IMapper mapper, IEmailTemplateService emailTemplateService, IOptions<HostingConfiguration> hostingOptions) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _emailTemplateService = emailTemplateService;
            _hostingOptions = hostingOptions;
        }

        protected override async Task<UserReadModel> Process(UserManagementCommand<UserForgotPasswordModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;

            // check for existing user
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(model.EmailAddress)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with email '{model.EmailAddress}' not found.");


            var resetToken = Guid.NewGuid().ToString("N");
            var resetHash = _passwordHasher.HashPassword(resetToken);

            user.ResetHash = resetHash;
            user.UpdatedBy = "system";
            user.Updated = DateTimeOffset.UtcNow;

            await _dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            var emailModel = new UserResetPasswordEmail
            {
                EmailAddress = user.EmailAddress,
                DisplayName = user.DisplayName,
                ResetToken = resetToken,
                UserAgent = message.UserAgent,
                ResetLink = $"{_hostingOptions.Value.ClientDomain}#/reset-password/{resetToken}"
            };

            await _emailTemplateService.SendResetPasswordEmail(emailModel).ConfigureAwait(false);

            // convert to read model
            var readModel = _mapper.Map<UserReadModel>(user);

            return readModel;
        }
    }
}