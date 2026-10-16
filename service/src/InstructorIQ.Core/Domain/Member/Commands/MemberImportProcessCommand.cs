using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record MemberImportProcessCommand : PrincipalCommandBase<MemberImportJobModel>
{
    public MemberImportProcessCommand(ClaimsPrincipal principal, MemberImportJobModel import) : base(principal)
    {
        Import = import;
    }

    public MemberImportJobModel Import { get; }
}
