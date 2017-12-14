using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Security
{
    /// <summary>
    /// Implements the standard Identity password hashing.
    /// </summary>
    /// <remarks>
    /// Based on the the source code for ASP.NET Core Identity's PasswordHasher
    /// </remarks>
    public class PasswordHasher : IPasswordHasher
    {
        /* =======================
         * HASHED PASSWORD FORMATS
         * =======================
         * Version 3:
         * PBKDF2 with HMAC-SHA256, 128-bit salt, 256-bit subkey, 10000 iterations.
         * Format: { 0x01, prf (UInt32), iter count (UInt32), salt length (UInt32), salt, subkey }
         * (All UInt32s are stored big-endian.)
         */
        private readonly int _iterationCount;
        private readonly RandomNumberGenerator _randomNumber;
        private const int _saltSize = 128 / 8; // 128-bit salt
        private const int _bytesRequested = 256 / 8; // 256-bit subkey

        public PasswordHasher(RandomNumberGenerator randomNumber, int iterationCount)
        {
            _randomNumber = randomNumber;
            _iterationCount = iterationCount;
        }

        public PasswordHasher() : this(RandomNumberGenerator.Create(), 10000)
        {
        }

        #region HashPassword
        /// <summary>
        /// Returns a hashed representation of the supplied <paramref name="password"/>.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>A hashed representation of the supplied <paramref name="password"/>.</returns>
        public virtual string HashPassword(string password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            var hashPassword = HashPassword(password, _randomNumber);
            return Convert.ToBase64String(hashPassword);
        }


        private byte[] HashPassword(string password, RandomNumberGenerator randomNumber)
        {

            return HashPassword(password, randomNumber, KeyDerivationPrf.HMACSHA256, _iterationCount, _saltSize, _bytesRequested);
        }

        private static byte[] HashPassword(string password, RandomNumberGenerator randomNumber, KeyDerivationPrf prf, int iterationCount, int saltSize, int numBytesRequested)
        {
            // Produce a version 3 (see comment above) text hash.
            byte[] salt = new byte[saltSize];
            randomNumber.GetBytes(salt);

            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterationCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // format marker

            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)iterationCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);

            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);

            return outputBytes;
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }
        #endregion

        #region VerifyPassword
        /// <summary>
        /// Verifies that the <paramref name="password"/> matches the <paramref name="hashedPassword"/>.
        /// </summary>
        /// <param name="hashedPassword">The hash value of stored password.</param>
        /// <param name="password">The password supplied for comparison.</param>
        /// <returns><c>true</c> indicating the passwords match; otherwise <c>false</c>.</returns>
        /// <remarks>Implementations of this method should be time consistent.</remarks>
        public virtual bool VerifyPassword(string hashedPassword, string password)
        {
            if (hashedPassword == null)
                throw new ArgumentNullException(nameof(hashedPassword));

            if (password == null)
                throw new ArgumentNullException(nameof(password));

            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            // read the format marker from the hashed password
            if (decodedHashedPassword.Length == 0)
                return false;

            var version = decodedHashedPassword[0];
            // unknown format marker
            if (version != 0x01)
                return false;

            return VerifyPassword(decodedHashedPassword, password, out var iterationCount);
        }


        private static bool VerifyPassword(byte[] hashedPassword, string password, out int iterationCount)
        {
            iterationCount = default(int);

            try
            {
                // Read header information
                KeyDerivationPrf prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
                iterationCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
                int saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

                // Read the salt: must be >= 128 bits
                if (saltLength < _saltSize)
                    return false;

                var salt = new byte[saltLength];
                Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

                // Read the subkey (the rest of the payload): must be >= 128 bits
                int subkeyLength = hashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                    return false;

                var expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // Hash the incoming password and verify it
                var actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterationCount, subkeyLength);
                return ByteArraysEqual(actualSubkey, expectedSubkey);
            }
            catch
            {
                // This should never occur except in the case of a malformed payload, where
                // we might go off the end of the array. Regardless, a malformed payload
                // implies verification failed.
                return false;
            }
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }

        // Compares two byte arrays for equality. The method is specifically written so that the loop is not optimized.
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a == null && b == null)
            {
                return true;
            }
            if (a == null || b == null || a.Length != b.Length)
            {
                return false;
            }
            var areSame = true;
            for (var i = 0; i < a.Length; i++)
            {
                areSame &= (a[i] == b[i]);
            }
            return areSame;
        }
        #endregion
    }
}
