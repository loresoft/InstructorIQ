using System;
using Xunit;

namespace InstructorIQ.Core.Tests
{
    [CollectionDefinition("DependencyInjectionCollection")]
    public class DependencyInjectionCollection : ICollectionFixture<DependencyInjectionFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}