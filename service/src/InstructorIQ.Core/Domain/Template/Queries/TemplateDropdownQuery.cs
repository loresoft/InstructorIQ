using System;
using System.Collections.Generic;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries;

public class TemplateDropdownQuery : PrincipalQueryBase<IReadOnlyCollection<TemplateDropdownModel>>
{
    public TemplateDropdownQuery(IPrincipal principal, string templateType) : base(principal)
    {
        TemplateType = templateType;
    }

    public string TemplateType { get; set; }
}
