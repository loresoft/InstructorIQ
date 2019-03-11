using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Calendar
{
    public class IndexModel : MediatorModelBase
    {
        public IndexModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
            Month = DateTime.Now.Month;
            Year = DateTime.Now.Year;
        }

        [BindProperty(Name = "year", SupportsGet = true)]
        public int Year { get; set; }

        [BindProperty(Name = "month", SupportsGet = true)]
        public int Month { get; set; }

        public IReadOnlyCollection<SessionCalendarModel> Items { get; set; }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            var month = Month;
            var year = Year;

            if (month == 0)
                month = DateTime.Now.Month;

            if (year == 0)
                year = DateTime.Now.Year;

            var command = new SessionCalendarQuery(User, month, year);
            var result = await Mediator.Send(command);

            Items = result;

            return Page();
        }

    }
}