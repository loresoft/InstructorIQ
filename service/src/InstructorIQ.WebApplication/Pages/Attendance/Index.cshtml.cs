using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Attendance
{
    public class IndexModel : MediatorModelBase
    {
        public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Year = DateTime.Now.Year;
            Week = DateTime.Now.GetWeekOfYear();
        }

        [BindProperty(Name = "year", SupportsGet = true)]
        public int Year { get; set; }

        [BindProperty(Name = "week", SupportsGet = true)]
        public int Week { get; set; }

        public int PreviousYear { get; set; }
        public int PreviousWeek { get; set; }

        public int NextYear { get; set; }
        public int NextWeek { get; set; }

        public IReadOnlyCollection<SessionCalendarModel> Items { get; set; }


        public virtual async Task<IActionResult> OnGetAsync()
        {
            if (Tenant == null || !Tenant.HasValue)
                return RedirectToPage("/Index");

            var week = Week;
            var year = Year;

            var now = DateTime.Now;
            var formatInfo = DateTimeFormatInfo.CurrentInfo;

            if (week == 0)
                year = now.GetWeekOfYear(formatInfo);

            if (year == 0)
                year = now.Year;

            var startDate = formatInfo.GetFirstDayOfWeek(year, week);
            var endDate = startDate.AddDays(6);

            ConfigureNext(formatInfo, startDate);

            var command = new SessionCalendarQuery(User, Tenant.Value.Id, startDate, endDate);
            var result = await Mediator.Send(command);

            Items = result
                .OrderBy(r => r.StartDate)
                .ThenBy(r => r.StartTime)
                .ToList();

            return Page();
        }

        private void ConfigureNext(DateTimeFormatInfo formatInfo, DateTime startDate)
        {
            var previousDate = formatInfo.Calendar.AddWeeks(startDate, -1);
            PreviousYear = previousDate.Year;
            PreviousWeek = previousDate.GetWeekOfYear(formatInfo);

            var nextDate = formatInfo.Calendar.AddWeeks(startDate, 1);
            NextYear = nextDate.Year;
            NextWeek = nextDate.GetWeekOfYear(formatInfo);
        }
    }
}