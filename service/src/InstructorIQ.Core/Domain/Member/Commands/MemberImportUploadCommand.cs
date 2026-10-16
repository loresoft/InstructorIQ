using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

using Microsoft.AspNetCore.Http;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record MemberImportUploadCommand : PrincipalCommandBase<MemberImportJobModel>
{

    public MemberImportUploadCommand(ClaimsPrincipal principal, IFormFile upload, Guid tenantId) : base(principal)
    {
        Upload = upload;
        TenantId = tenantId;
    }

    public IFormFile Upload { get; }

    public Guid TenantId { get; }
}
