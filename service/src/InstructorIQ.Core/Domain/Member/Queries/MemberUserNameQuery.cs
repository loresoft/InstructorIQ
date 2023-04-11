using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class MemberUserNameQuery : CacheableQueryBase<MemberReadModel>
{
    public MemberUserNameQuery(IPrincipal principal, string userName)
        : base(principal)
    {
        UserName = userName;
    }

    public string UserName { get; }

    public override string GetCacheKey()
    {
        return $"{typeof(MemberReadModel).FullName}-{UserName}";
    }
}
