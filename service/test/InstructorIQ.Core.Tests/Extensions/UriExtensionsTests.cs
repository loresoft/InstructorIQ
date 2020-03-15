using System;
using FluentAssertions;
using InstructorIQ.Core.Extensions;
using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Extensions
{
    public class UriExtensionsTests : UnitTestBase
    {
        public UriExtensionsTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void ToLocalPath()
        {
            var uri = new Uri("https://instructoriq.com/path/test?test=v#one");

            var localPath = uri.ToLocalPath();
            localPath.Should().Be("/path/test?test=v#one");

            uri = new Uri("/blah/test?test=v#one", UriKind.Relative);
            localPath = uri.ToLocalPath();
            localPath.Should().Be("/blah/test?test=v#one");
        }
    }
}