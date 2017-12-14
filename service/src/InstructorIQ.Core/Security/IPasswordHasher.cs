using System;

namespace InstructorIQ.Core.Security
{
    /// <summary>
    /// Provides an abstraction for hashing passwords.
    /// </summary>
    public interface IPasswordHasher
    {
        /// <summary>
        /// Returns a hashed representation of the supplied <paramref name="password"/> for the specified <paramref name="user"/>.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>A hashed representation of the supplied <paramref name="password"/> for the specified <paramref name="user"/>.</returns>
        string HashPassword(string password);

        /// <summary>
        /// Verifies that the <paramref name="password"/> matches the <paramref name="hashedPassword"/>.
        /// </summary>
        /// <param name="hashedPassword">The hash value of stored password.</param>
        /// <param name="password">The password supplied for comparison.</param>
        /// <returns><c>true</c> indicating the passwords match; otherwise <c>false</c>.</returns>
        /// <remarks>Implementations of this method should be time consistent.</remarks>
        bool VerifyPassword(string hashedPassword, string password);
    }
}