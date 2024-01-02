using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using NaturalSort.Extension;

namespace InstructorIQ.WebApplication.Pages.Report.Summary;

public abstract class SummaryModel : MediatorModelBase
{
    protected SummaryModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
        Date = DateOnly.FromDateTime(DateTime.Now);
    }

    [BindProperty(Name = "date", SupportsGet = true)]
    public DateOnly Date { get; set; }

    public string MonthName => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Date.Month);


    public DateOnly NextMonth => Date.AddMonths(1);

    public string NextMonthName => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(NextMonth.Month);


    public DateOnly NextYear => Date.AddMonths(12);


    public bool ShowNextMonth()
    {
        var first = new DateOnly(NextMonth.Year, NextMonth.Month, 1);
        var diff = first.DayNumber - Date.DayNumber;
        return diff < 15;
    }

    public bool ShowNextYear()
    {
        
        var first = new DateOnly(NextYear.Year, 1, 1);
        var diff = first.DayNumber - Date.DayNumber;
        return diff < 45;
    }

    public IReadOnlyCollection<SessionCalendarModel> Items { get; set; }

    protected async Task Load()
    {
        var startDate = Date;
        var endDate = startDate.AddDays(1);

        var command = new SessionCalendarQuery(User, Tenant.Value.Id, startDate, endDate);
        var result = await Mediator.Send(command);

        Items = result
            .OrderBy(i => i.StartTime)
            .ThenBy(i => i.GroupName, StringComparer.OrdinalIgnoreCase.WithNaturalSort())
            .ThenBy(i => i.TopicTitle)
            .ToList();
    }
}
