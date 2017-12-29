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
        public async Task ForgotPassword()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var registerModel = new UserForgotPasswordModel
            {
                EmailAddress = "test@mailinator.com",
            };

            var command = new UserManagementCommand<UserForgotPasswordModel>(registerModel);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();
            result.EmailAddress.Should().Be(registerModel.EmailAddress);
        }

        [Fact]
        public async Task LoginUser()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var userAgent = new UserAgentModel
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36",
                Browser = "Chrome",
                DeviceBrand = "",
                DeviceFamily = "Other",
                DeviceModel = "",
                OperatingSystem = "Windows 10",
                IpAddress = "127.0.0.1"
            };

            var request = new TokenRequest
            {
                GrantType = "password",
                ClientId = "UnitTest",
                UserName = $"test@mailinator.com",
                Password = "Th!s My Passw@ord"
            };

            var command = new AuthenticateCommand(userAgent, request);

            var result = await mediator.Send(command).ConfigureAwait(false);
            result.Should().NotBeNull();

        }
    }
}