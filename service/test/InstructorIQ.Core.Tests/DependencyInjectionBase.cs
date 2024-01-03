using System;

using Xunit;
using Xunit.Abstractions;

using XUnit.Hosting;

namespace InstructorIQ.Core.Tests;

[Collection("DependencyInjectionCollection")]
public abstract class DependencyInjectionBase : TestHostBase<DependencyInjectionFixture>
{
    protected DependencyInjectionBase(ITestOutputHelper output, DependencyInjectionFixture databaseFixture)
        : base(output, databaseFixture)
    {
    }

    public IServiceProvider ServiceProvider => Fixture.Services;
}
