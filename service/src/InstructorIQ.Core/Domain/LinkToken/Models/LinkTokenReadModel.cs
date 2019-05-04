using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class LinkTokenReadModel
    {
        public string UserName { get; set; }
        public string Url { get; set; }
        public Guid? TenantId { get; set; }
    }
}