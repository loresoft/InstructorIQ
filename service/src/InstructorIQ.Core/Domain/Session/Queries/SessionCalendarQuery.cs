using System.Collections.Generic;
using System.Security.Principal;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class SessionCalendarQuery : PrincipalQueryBase<IReadOnlyCollection<SessionCalendarModel>>
    {
        public SessionCalendarQuery(IPrincipal principal, int month, int year)
            : base(principal)
        {
            Month = month;
            Year = year;
        }

        public int Year { get; set; }

        public int Month { get; set; }

    }
}