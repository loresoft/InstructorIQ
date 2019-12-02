using System;
using MediatR.CommandQuery.Definitions;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class TemplateEditorModel : IHaveIdentifier<Guid>, IHaveTenant<Guid>

    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public Guid TenantId { get; set; }
    }
}
