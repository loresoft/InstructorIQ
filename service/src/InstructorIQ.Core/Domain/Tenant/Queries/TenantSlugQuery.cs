using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Definitions;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record TenantSlugQuery : PrincipalQueryBase<TenantReadModel>, ICacheResult
{
    public TenantSlugQuery(ClaimsPrincipal principal, string slug) : base(principal)
    {
        Slug = slug;
    }

    public string Slug { get; set; }


    string ICacheResult.GetCacheKey()
    {
        return $"tenant-slug-{Slug?.ToLowerInvariant()}";
    }

    string ICacheResult.GetCacheTag()
    {
        return "Tenant";
    }

    TimeSpan? ICacheResult.SlidingExpiration()
    {
        return TimeSpan.FromMinutes(10);
    }

    DateTimeOffset? ICacheResult.AbsoluteExpiration()
    {
        return DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(30));
    }

    bool ICacheResult.IsCacheable()
    {
        return true;
    }
}
