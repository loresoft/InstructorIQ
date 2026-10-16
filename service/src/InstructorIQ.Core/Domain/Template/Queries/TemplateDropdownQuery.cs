using System;
using System.Collections.Generic;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public record TemplateDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<TemplateDropdownModel>>
{
    public TemplateDropdownQuery(ClaimsPrincipal principal, string templateType) : base(principal)
    {
        TemplateType = templateType;
    }

    public string TemplateType { get; set; }
}
