using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class LinkTokenCreateModel
    {
        public string UserName { get; set; }
        public string Url { get; set; }
        public Guid? TenantId { get; set; }
        public DateTimeOffset? Expires { get; set; }
    }
}
