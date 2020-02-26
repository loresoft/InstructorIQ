using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class AttendanceSessionQuery : PrincipalQueryBase<IReadOnlyCollection<AttendanceSessionModel>>
    {
        public AttendanceSessionQuery(IPrincipal principal, Guid tenantId) : base(principal)
        {
            TenantId = tenantId;
        }

        public AttendanceSessionQuery(IPrincipal principal, Guid tenantId, int year)
            : base(principal)
        {
            TenantId = tenantId;

            StartDate = new DateTime(year, 1, 1);
            EndDate = StartDate.Value.AddYears(1);
        }

        public AttendanceSessionQuery(IPrincipal principal, Guid tenantId, int year, int month)
            : base(principal)
        {
            TenantId = tenantId;

            StartDate = new DateTime(year, month, 1);
            EndDate = StartDate.Value.AddMonths(1);
        }

        public AttendanceSessionQuery(IPrincipal principal, Guid tenantId, Guid topicId) : base(principal)
        {
            TenantId = tenantId;
            TopicId = topicId;
        }


        public Guid TenantId { get; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? TopicId { get; set; }

        public string UserName { get; set; }

        public string SearchText { get; set; }
    }
}
