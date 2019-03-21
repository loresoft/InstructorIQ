using System;
using System.Collections.Generic;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class SessionCalendarQuery : PrincipalQueryBase<IReadOnlyCollection<SessionCalendarModel>>
    {
        public SessionCalendarQuery(IPrincipal principal, Guid tenantId, int year)
            : base(principal)
        {
            TenantId = tenantId;
            Year = year;
        }

        public SessionCalendarQuery(IPrincipal principal, Guid tenantId, int year, int month)
            : base(principal)
        {
            TenantId = tenantId;
            Month = month;
            Year = year;
        }

        public Guid TenantId { get; set; }

        public int Year { get; set; }

        public int? Month { get; set; }
    }
}