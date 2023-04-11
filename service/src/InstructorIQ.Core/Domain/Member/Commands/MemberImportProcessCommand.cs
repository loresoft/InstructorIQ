using System;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public class MemberImportProcessCommand : PrincipalCommandBase<MemberImportJobModel>
{
    public MemberImportProcessCommand(IPrincipal principal, MemberImportJobModel import) : base(principal)
    {
        Import = import;
    }

    public MemberImportJobModel Import { get; }
}
