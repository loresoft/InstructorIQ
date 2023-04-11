using System;
using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class MemberDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<MemberDropdownModel>>
{
    public MemberDropdownQuery(IPrincipal principal, Guid tenantId)
        : base(principal)
    {
        TenantId = tenantId;
    }

    public Guid TenantId { get; }

    public Guid? RoleId { get; set; }
}
