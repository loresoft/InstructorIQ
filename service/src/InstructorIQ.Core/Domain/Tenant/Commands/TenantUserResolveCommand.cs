using System.Security.Claims;

using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record TenantUserResolveCommand : PrincipalCommandBase<TenantUserModel>
{
    public TenantUserResolveCommand(ClaimsPrincipal principal, User user) : base(principal)
    {
        User = user;
    }

    public User User { get; set; }
}
