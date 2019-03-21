using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Calendar
{
    public class YearlyModel : MediatorModelBase
    {
        public YearlyModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Year = DateTime.Now.Year;
        }

        [BindProperty(Name = "year", SupportsGet = true)]
        public int Year { get; set; }

        public IReadOnlyCollection<SessionCalendarModel> Items { get; set; }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            if (Tenant == null || !Tenant.HasValue)
                return RedirectToPage("/Index");

            var year = Year;

            if (year == 0)
                year = DateTime.Now.Year;

            var command = new SessionCalendarQuery(User, Tenant.Value.Id, year);
            var result = await Mediator.Send(command);

            Items = result;

            return Page();
        }

    }
}