using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using FluentAssertions;
using Microsoft.AspNetCore.WebUtilities;
using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Security
{
    public class SecretGeneratorTest : UnitTestBase
    {
        public SecretGeneratorTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void GenerateClientSecret()
        {
            int bytes = 32;

            byte[] data;
            using (var rngCsp = RandomNumberGenerator.Create())
            {
                data = new byte[bytes];
                rngCsp.GetNonZeroBytes(data);
            }

            var audienceSecret = Base64UrlTextEncoder.Encode(data);
            var audienceId = Guid.NewGuid().ToString("N");

            OutputHelper.WriteLine($"audienceId: {audienceId}");
            OutputHelper.WriteLine($"audienceSecret: {audienceSecret}");
        }

        [Fact]
        public void UnionTest()
        {
            var existing = new List<int> { 1, 2, 3 };
            var updated = new List<int> { 2, 4 };

            var remove = existing
                .Except(updated)
                .ToList();

            remove.Should().Contain(new[] {1, 3});

            var insert = updated
                .Except(existing)
                .ToList();

            insert.Should().Contain(new[] { 4 });

        }
    }
}
