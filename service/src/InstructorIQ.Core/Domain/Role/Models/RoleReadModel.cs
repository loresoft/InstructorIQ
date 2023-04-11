using System;

using MediatR.CommandQuery.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models;

public class RoleReadModel : IHaveIdentifier<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}
