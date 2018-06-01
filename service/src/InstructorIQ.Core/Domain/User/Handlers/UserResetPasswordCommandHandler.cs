using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.User.Commands;
using InstructorIQ.Core.Domain.User.Models;
using InstructorIQ.Core.Security;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.User.Handlers
{
    public class UserResetPasswordCommandHandler : RequestHandlerBase<UserManagementCommand<UserResetPasswordModel>, UserReadModel>
    {
        private readonly InstructorIQContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserResetPasswordCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IPasswordHasher passwordHasher, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        protected override async Task<UserReadModel> Process(UserManagementCommand<UserResetPasswordModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;

            // check for existing user
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(model.EmailAddress)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with email '{model.EmailAddress}' not found.");

            if (!_passwordHasher.VerifyPassword(user.ResetHash, model.ResetToken))
                throw new DomainException(HttpStatusCode.Forbidden, "Invalid reset password security token.");


            var passwordHashed = _passwordHasher
                .HashPassword(model.UpdatedPassword);

            user.PasswordHash = passwordHashed;
            user.AccessFailedCount = 0;
            user.LockoutEnabled = false;
            user.LockoutEnd = null;
            user.Updated = DateTimeOffset.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            // convert to read model
            var readModel = _mapper.Map<UserReadModel>(user);

            return readModel;
        }
    }
}