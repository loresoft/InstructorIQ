using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class GroupSequenceModel
    {
        public int Sequence { get; set; }

        public string Name { get; set; }

        public Guid TenantId { get; set; }    }
}