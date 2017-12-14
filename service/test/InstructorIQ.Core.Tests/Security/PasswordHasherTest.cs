using System;
using System.Security.Cryptography;
using FluentAssertions;
using InstructorIQ.Core.Security;
using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests.Security
{
    public class PasswordHasherTest : UnitTestBase
    {
        public PasswordHasherTest(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public void HashPassword()
        {
            var hasher = new PasswordHasher(new SequentialRandomNumberGenerator(), 10000);
            string result = hasher.HashPassword("my password");

            result.Should().Be("AQAAAAEAACcQAAAAEAABAgMEBQYHCAkKCwwNDg+yWU7rLgUwPZb1Itsmra7cbxw2EFpwpVFIEtP+JIuUEw==");
        }

        [Theory]
        [InlineData("AQAAAAIAAAAyAAAAEOMwvh3+FZxqkdMBz2ekgGhwQ4B6pZWND6zgESBuWiHw")] // SHA512, 50 iterations, 128-bit salt, 128-bit subkey
        [InlineData("AQAAAAIAAAD6AAAAIJbVi5wbMR+htSfFp8fTw8N8GOS/Sje+S/4YZcgBfU7EQuqv4OkVYmc4VJl9AGZzmRTxSkP7LtVi9IWyUxX8IAAfZ8v+ZfhjCcudtC1YERSqE1OEdXLW9VukPuJWBBjLuw==")] // SHA512, 250 iterations, 256-bit salt, 512-bit subkey
        [InlineData("AQAAAAAAAAD6AAAAEAhftMyfTJylOlZT+eEotFXd1elee8ih5WsjXaR3PA9M")] // SHA1, 250 iterations, 128-bit salt, 128-bit subkey
        [InlineData("AQAAAAEAA9CQAAAAIESkQuj2Du8Y+kbc5lcN/W/3NiAZFEm11P27nrSN5/tId+bR1SwV8CO1Jd72r4C08OLvplNlCDc3oQZ8efcW+jQ=")] // SHA256, 250000 iterations, 256-bit salt, 256-bit subkey
        public void VerifyPasswordSuccessCases(string hashedPassword)
        {
            var hasher = new PasswordHasher(new SequentialRandomNumberGenerator(), 10000);
            var result = hasher.VerifyPassword(hashedPassword, "my password");

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("AQAAAAAAAAD6AAAAEAhftMyfTJyAAAAAAAAAAAAAAAAAAAih5WsjXaR3PA9M")] // incorrect password
        [InlineData("AQAAAAIAAAAyAAAAEOMwvh3+FZxqkdMBz2ekgGhwQ4A=")] // too short
        [InlineData("AQAAAAIAAAAyAAAAEOMwvh3+FZxqkdMBz2ekgGhwQ4B6pZWND6zgESBuWiHwAAAAAAAAAAAA")] // extra data at end
        public void VerifyPasswordFailureCases(string hashedPassword)
        {
            var hasher = new PasswordHasher(new SequentialRandomNumberGenerator(), 10000);
            var result = hasher.VerifyPassword(hashedPassword, "my password");

            result.Should().BeFalse();
        }

        private sealed class SequentialRandomNumberGenerator : RandomNumberGenerator
        {
            private byte _value;

            public override void GetBytes(byte[] data)
            {
                for (int i = 0; i < data.Length; i++)
                    data[i] = _value++;
            }
        }
    }
}