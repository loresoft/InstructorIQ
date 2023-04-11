using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.Core.Services;
using InstructorIQ.WebApplication.Models;

using MediatR;
using MediatR.CommandQuery.Queries;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Attendance;

[Authorize(Policy = UserPolicies.UserPolicy)]
public class TopicModel : MediatorModelBase
{
    private readonly IStateService _stateService;

    public TopicModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, IStateService stateService)
        : base(tenant, mediator, loggerFactory)
    {
        _stateService = stateService;
    }


    [BindProperty(Name = "q", SupportsGet = true)]
    public string Query { get; set; }

    [BindProperty(Name = "year", SupportsGet = true)]
    public int? Year { get; set; }

    [BindProperty(Name = "month", SupportsGet = true)]
    public int? Month { get; set; }

    [BindProperty(Name = "topicId", SupportsGet = true)]
    public Guid? TopicId { get; set; }


    public IReadOnlyCollection<TopicDropdownModel> Topics { get; set; }

    public IReadOnlyCollection<AttendanceSessionModel> Items { get; set; }


    public async Task<IActionResult> OnGetAsync()
    {
        ReadHistory();

        var loadTask = LoadItems();
        var loadTopicsTask = LoadTopics();

        // load all in parallel
        await Task.WhenAll(
            loadTask,
            loadTopicsTask
        );

        Items = loadTask.Result;
        Topics = loadTopicsTask.Result;

        WriteHistory();

        return Page();
    }


    private async Task<IReadOnlyCollection<TopicDropdownModel>> LoadTopics()
    {
        var select = new EntitySelect();

        if (Year.HasValue)
        {
            var filter = new EntityFilter();
            filter.Name = nameof(Core.Data.Entities.Topic.CalendarYear);
            filter.Value = Year.Value;

            select.Filter = filter;
        }

        var query = new EntitySelectQuery<TopicDropdownModel>(User, select);
        var topics = await Mediator.Send(query);

        return topics
            .OrderBy(p => p.Text)
            .ToList();
    }

    private async Task<IReadOnlyCollection<AttendanceSessionModel>> LoadItems()
    {
        var command = new AttendanceSessionQuery(User, Tenant.Value.Id);
        command.SearchText = Query;
        command.TopicId = TopicId;

        if (Year.HasValue && Month.HasValue && Month.Value > 0)
        {
            var startDate = new DateTime(Year.Value, Month.Value, 1);
            command.StartDate = startDate;
            command.EndDate = startDate.AddMonths(1);
        }
        else if (Year.HasValue)
        {
            var startDate = new DateTime(Year.Value, 1, 1);
            command.StartDate = startDate;
            command.EndDate = startDate.AddYears(1);
        }

        var result = await Mediator.Send(command);

        return result;
    }

    private void WriteHistory()
    {
        var state = new SessionQueryState
        {
            Year = Year,
            Month = Month,
            Query = Query,
            TopicId = TopicId
        };

        _stateService.WriteState(state, "attend_topic");
    }

    private void ReadHistory()
    {
        var state = _stateService.ReadState<SessionQueryState>("attend_topic");
        if (Year == null || Year == 0)
            Year = state?.Year ?? DateTime.Now.Year;

        if (Month == null)
            Month = state?.Month ?? DateTime.Now.Month;

        if (!Request.Query.ContainsKey("q"))
            Query = state?.Query?.Trim();

        if (!Request.Query.ContainsKey("topicId"))
            TopicId = state?.TopicId;
    }

}
