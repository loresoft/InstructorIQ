using System;
using System.Threading.Tasks;
using FluentAssertions;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Mediator
{
    public class UserEntityTest : DependencyInjectionBase
    {
        public UserEntityTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task RegisterUser()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var registerModel = new UserRegisterModel
            {
                DisplayName = "Test User",
                EmailAddress = $"test.{DateTime.Now.Ticks}@mailinator.com",
                Password = "Th!s My Passw@ord"
            };

            var command = new UserManagementCommand<UserRegisterModel>(registerModel);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();
            result.EmailAddress.Should().Be(registerModel.EmailAddress);
            result.DisplayName.Should().Be(registerModel.DisplayName);

        }

        [Fact]
        public async Task LoginUser()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var model = new TokenRequest
            {
                GrantType = "password",
                UserName = $"test@mailinator.com",
                Password = "Th!s My Passw@ord"
            };

            var command = new AuthenticateCommand(model);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }
    }
}