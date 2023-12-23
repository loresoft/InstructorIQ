using System;

using Xunit;

namespace InstructorIQ.Core.Tests;

[CollectionDefinition("DependencyInjectionCollection")]
public class DependencyInjectionCollection : ICollectionFixture<DependencyInjectionFixture>
{
}
