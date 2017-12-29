using System;
using System.Security.Cryptography;
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
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                data = new byte[bytes];
                rngCsp.GetNonZeroBytes(data);
            }

            var audienceSecret = Base64UrlTextEncoder.Encode(data);
            var audienceId = Guid.NewGuid().ToString("N");

            OutputHelper.WriteLine($"audienceId: {audienceId}");
            OutputHelper.WriteLine($"audienceSecret: {audienceSecret}");
        }

    }
}
