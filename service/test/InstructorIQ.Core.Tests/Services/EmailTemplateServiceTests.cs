using System;
using System.Collections.Generic;
using System.Text;

using FluentAssertions;

using InstructorIQ.Core.Services;

using Microsoft.Extensions.DependencyInjection;

using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Services;

[Collection("DependencyInjectionCollection")]
public class EmailTemplateServiceTests : DependencyInjectionBase
{
    public EmailTemplateServiceTests(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
        : base(outputHelper, dependencyInjection)
    {
    }

    [Theory]
    [InlineData("reset-password")]
    [InlineData("passwordless-login")]
    [InlineData("user-invite")]
    public void GetResourceTemplate(string templateKey)
    {
        var emailService = ServiceProvider.GetService<IEmailTemplateService>();
        emailService.Should().NotBeNull();

        var template = emailService.GetResourceTemplate(templateKey);
        template.Should().NotBeNull();
        template.FromAddress.Should().NotBeNullOrEmpty();
        template.Subject.Should().NotBeNullOrEmpty();
        template.TextBody.Should().NotBeNullOrEmpty();
        template.HtmlBody.Should().NotBeNullOrEmpty();
    }

}
