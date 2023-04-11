using System;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries
{
    public class LogEventQuery : PrincipalQueryBase<LogPagedResult>
    {
        public LogEventQuery(IPrincipal principal) : base(principal)
        {

        }

        public string ContinuationToken { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        public string Level { get; set; }

        public int PageSize { get; set; } = 100;
    }
}
