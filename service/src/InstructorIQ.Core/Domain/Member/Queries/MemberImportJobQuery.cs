using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record MemberImportJobQuery : EntityIdentifierQuery<Guid, MemberImportJobModel>
{
    public MemberImportJobQuery(ClaimsPrincipal principal, Guid id) : base(principal, id)
    {
    }
}
