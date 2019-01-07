using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
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

            if (!Guid.TryParse(userId, out var userGuid))
                throw new DomainException(422, $"Invalid user identifier '{userId}'.");

            // check for existing user
            var user = await _dataContext.Users
                .FindAsync(userGuid)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with email '{emailAddress}' not found.");

            if (!_passwordHasher.VerifyPassword(user.PasswordHash, model.CurrentPassword))
                throw new DomainException(HttpStatusCode.Forbidden, "The password is incorrect");

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