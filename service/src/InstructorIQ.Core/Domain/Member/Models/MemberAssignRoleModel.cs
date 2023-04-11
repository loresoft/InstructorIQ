using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

public class MemberAssignRoleModel
{
    public Guid TenantId { get; set; }

    public string UserName { get; set; }

    public string RoleName { get; set; }
}
