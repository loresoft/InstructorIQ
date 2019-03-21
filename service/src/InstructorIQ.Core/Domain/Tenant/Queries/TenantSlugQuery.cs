using System;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Definitions;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class TenantSlugQuery : PrincipalQueryBase<TenantReadModel>, ICacheQueryResult
    {
        public TenantSlugQuery(IPrincipal principal, string slug) : base(principal)
        {
            Slug = slug;
        }

        public string Slug { get; set; }


        string ICacheQueryResult.GetCacheKey()
        {
            return $"tenant-slug-{Slug?.ToLowerInvariant()}";
        }

        TimeSpan? ICacheQueryResult.SlidingExpiration()
        {
            return TimeSpan.FromMinutes(10);
        }

        DateTimeOffset? ICacheQueryResult.AbsoluteExpiration()
        {
            return DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(30));
        }
    }
}
