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
    public class UserRegisterCommandHandler : RequestHandlerBase<UserManagementCommand<UserRegisterModel>, UserReadModel>
    {
        private readonly InstructorIQContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserRegisterCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IPasswordHasher passwordHasher, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        protected override async Task<UserReadModel> Process(UserManagementCommand<UserRegisterModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;

            // check for existing user
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(model.EmailAddress)
                .ConfigureAwait(false);

            if (user != null)
                throw new MediatorException(422, $"User with email '{model.EmailAddress}' already exists.");

            var passwordHashed = _passwordHasher
                .HashPassword(model.Password);

            user = new Data.Entities.User
            {
                EmailAddress = model.EmailAddress,
                DisplayName = model.DisplayName,
                PasswordHash = passwordHashed,
                Created = DateTimeOffset.UtcNow,
                Updated = DateTimeOffset.UtcNow
            };

            await _dataContext.Users
                .AddAsync(user, cancellationToken)
                .ConfigureAwait(false);

            await _dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // convert to read model
            var readModel = _mapper.Map<UserReadModel>(user);

            return readModel;
        }
    }
}
