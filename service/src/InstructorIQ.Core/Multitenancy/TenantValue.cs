using System;

namespace InstructorIQ.Core.Multitenancy;

public class TenantValue<TTenant> : ITenant<TTenant>
{
    public TenantValue(TTenant tenant)
    {
        Value = tenant;
    }

    public TTenant Value { get; }

    public bool HasValue => Value != null;
}
