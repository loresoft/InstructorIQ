using System;
using System.Security.Principal;

namespace InstructorIQ.Core.Tests
{
    public class MockIdentity : IIdentity
    {
        public MockIdentity(string name, string authenticationType, bool isAuthenticated)
        {
            AuthenticationType = authenticationType;
            IsAuthenticated = isAuthenticated;
            Name = name;
        }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string Name { get; }
    }
}