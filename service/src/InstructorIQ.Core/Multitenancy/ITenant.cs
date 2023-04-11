using System;

namespace InstructorIQ.Core.Multitenancy;

public interface ITenant<out TTenant>
{
    TTenant Value { get; }
    bool HasValue { get; }
}
