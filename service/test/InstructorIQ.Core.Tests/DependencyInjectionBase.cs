using System;

using Xunit;
using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests;

[Collection("DependencyInjectionCollection")]
public abstract class DependencyInjectionBase : UnitTestBase
{
    public DependencyInjectionFixture DependencyInjection { get; }

    protected DependencyInjectionBase(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection) : base(outputHelper)
    {
        DependencyInjection = dependencyInjection;
    }

    public IServiceProvider ServiceProvider => DependencyInjection.ServiceProvider;
}
