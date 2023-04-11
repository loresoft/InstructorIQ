using System;

using Xunit.Abstractions;

namespace InstructorIQ.Core.Tests;

public abstract class UnitTestBase
{
    protected UnitTestBase(ITestOutputHelper outputHelper)
    {
        OutputHelper = outputHelper;

    }

    public ITestOutputHelper OutputHelper { get; }
}
