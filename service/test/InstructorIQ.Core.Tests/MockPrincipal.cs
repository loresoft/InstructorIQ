using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace InstructorIQ.Core.Tests
{
    public class MockPrincipal : IPrincipal
    {
        private readonly HashSet<string> _roles;

        public MockPrincipal(IIdentity identity, IEnumerable<string> roles)
        {
            _roles = new HashSet<string>(roles);
            Identity = identity;
        }

        public MockPrincipal(string name)
            : this(new MockIdentity(name, "basic", true), Enumerable.Empty<string>())
        {

        }

        public bool IsInRole(string role)
        {
            return _roles.Contains(role);
        }

        public IIdentity Identity { get; }

        public IReadOnlyCollection<string> Roles => _roles;

        public static IPrincipal Default => new MockPrincipal("test.user@email.com");
    }
}
