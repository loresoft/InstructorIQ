using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Queries;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Security;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class UserForgotPasswordCommandHandler : RequestHandlerBase<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>
    {
        private readonly InstructorIQContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserForgotPasswordCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IPasswordHasher passwordHasher, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        protected override async Task<UserReadModel> Process(UserManagementCommand<UserForgotPasswordModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;

            // check for existing user
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(model.EmailAddress)
                .ConfigureAwait(false);

            if (user == null)
                throw new MediatorException(422, $"User with email '{model.EmailAddress}' not found.");


            var securityToken = Guid.NewGuid().ToString("N");
            var securityStamp = _passwordHasher.HashPassword(securityToken);

            user.SecurityStamp = securityStamp;
            user.UpdatedBy = "system";
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