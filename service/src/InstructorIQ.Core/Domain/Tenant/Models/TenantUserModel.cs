using System.Collections.Generic;

using InstructorIQ.Core.Data.Entities;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

public class TenantUserModel
{
    public User User { get; set; }

    public TenantReadModel Tenant { get; set; }

    public List<string> Roles { get; set; }
}
