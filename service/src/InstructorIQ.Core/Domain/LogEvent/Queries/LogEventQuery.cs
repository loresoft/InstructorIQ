using System;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

namespace InstructorIQ.Core.Domain.Queries
{
    public class LogEventQuery : PrincipalQueryBase<EntityPagedResult<LogEventModel>>
    {
        public LogEventQuery(IPrincipal principal) : base(principal)
        {

        }

        public DateTime Date { get; set; } = DateTime.Today;

        public string Level { get; set; }

        public string Search { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 100;
    }
}
