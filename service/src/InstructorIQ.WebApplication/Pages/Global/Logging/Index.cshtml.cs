using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentCommand.Extensions;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Global.Logging
{
    [Authorize(Policy = UserPolicies.GlobalAdministratorPolicy)]
    public class IndexModel : MediatorModelBase
    {
        public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty(Name = "p", SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        [BindProperty(Name = "z", SupportsGet = true)]
        public int PageSize { get; set; } = 100;

        [BindProperty(Name = "q", SupportsGet = true)]
        public string Query { get; set; } = string.Empty;

        [BindProperty(Name = "l", SupportsGet = true)]
        public string Level { get; set; } = string.Empty;

        [BindProperty(Name = "d", SupportsGet = true)]
        public DateTime Date { get; set; } = DateTime.Today;

        public long Total { get; set; }

        public IReadOnlyCollection<LogEventModel> Logs { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = new LogEventQuery(User)
            {
                Date = Date.Date,
                Level = Level.IsNullOrWhiteSpace() ? null : Level,
                Search = Query.IsNullOrWhiteSpace() ? null : $"%{Query}%",
                Page = PageNumber,
                PageSize = PageSize
            };

            var result = await Mediator.Send(query);

            Total = result.Total;
            Logs = result.Data ?? new List<LogEventModel>();

            return Page();
        }
    }
}