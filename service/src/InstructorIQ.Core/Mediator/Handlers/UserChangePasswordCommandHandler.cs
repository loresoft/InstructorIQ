using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Security;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class UserChangePasswordCommandHandler : RequestHandlerBase<UserManagementCommand<UserChangePasswordModel>, UserReadModel>
    {
        private readonly InstructorIQContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserChangePasswordCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IPasswordHasher passwordHasher, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        protected override async Task<UserReadModel> Process(UserManagementCommand<UserChangePasswordModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;
            var userId = message.Principal.Identity.GetUserId();
            var emailAddress = message.Principal.Identity.GetUserName();

            // check for existing user
            var user = await _dataContext.Users
                .FindAsync(userId)
                .ConfigureAwait(false);

            if (user == null)
                throw new MediatorException(422, $"User with email '{emailAddress}' not found.");

            if (!_passwordHasher.VerifyPassword(user.PasswordHash, model.CurrentPassword))
                throw new MediatorException(401, "The password is incorrect");

            var passwordHashed = _passwordHasher
                .HashPassword(model.UpdatedPassword);

            user.PasswordHash = passwordHashed;
            user.UpdatedBy = emailAddress;
            user.Updated = DateTimeOffset.UtcNow;

            await _dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // convert to read model
            var readModel = _mapper.Map<UserReadModel>(user);

            return readModel;
        }
    }
}