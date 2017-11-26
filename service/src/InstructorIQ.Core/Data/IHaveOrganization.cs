using System;

namespace InstructorIQ.Core.Data
{
    public interface IHaveOrganization
    {
        Guid OrganizationId { get; set; }
    }
}