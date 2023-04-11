using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;

using MediatR;
using MediatR.CommandQuery.Queries;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Session;

[Authorize(Policy = UserPolicies.AdministratorPolicy)]
public class MultipleModel : MediatorModelBase
{
    public MultipleModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
    }

    [BindProperty(SupportsGet = true)]
    public List<Guid> TopicIds { get; set; }

    [BindProperty]
    public List<SessionMultipleUpdateModel> Sessions { get; set; }

    public IReadOnlyCollection<TopicReadModel> Topics { get; set; }

    public IReadOnlyCollection<MemberDropdownModel> Instructors { get; set; }

    public IReadOnlyCollection<LocationDropdownModel> Locations { get; set; }

    public IReadOnlyCollection<GroupDropdownModel> Groups { get; set; }

    public IReadOnlyCollection<SessionFrequentTimeModel> Times { get; private set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var loadTask = LoadData();
        var sessionsTask = LoadSessions();

        // load all in parallel
        await Task.WhenAll(
            sessionsTask,
            loadTask
        );

        var title = Topics.Select(t => t.Title).ToDelimitedString("; ");

        // shared layout title
        ViewData["TopicTitle"] = $" - {title}";

        // convert to multiple update
        Sessions = sessionsTask.Result
            .OrderBy(s => s.TopicTitle)
            .ThenBy(t => t.TopicId)
            .ThenBy(s => s.StartDate)
            .ThenBy(s => s.StartTime)
            .Select(i => new SessionMultipleUpdateModel
            {
                Id = i.Id,
                StartDate = i.StartDate,
                StartTime = i.StartTime,
                EndDate = i.EndDate,
                EndTime = i.EndTime,
                GroupId = i.GroupId,
                LeadInstructorId = i.LeadInstructorId,
                LocationId = i.LocationId,
                Note = i.Note,
                TopicId = i.TopicId,
                TopicTitle = i.TopicTitle,
                TenantId = i.TenantId,

                AdditionalInstructors = i.AdditionalInstructors.Select(s => s.InstructorId).ToList()
            })

            .ToList();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            await LoadData();
            return Page();
        }

        var updateCommand = new SessionMultipleUpdateCommand(User, Sessions);
        var result = await Mediator.Send(updateCommand);

        ShowAlert("Successfully saved topic sessions");

        return RedirectToPage("/Topic/Index", new { tenant = TenantRoute });
    }

    private async Task LoadData()
    {
        var topicTask = LoadTopics();
        var instructorTask = LoadInstructors();
        var locationTask = LoadLocations();
        var groupTask = LoadGroups();
        var timesTask = LoadTimes();

        // load all in parallel
        await Task.WhenAll(
            topicTask,
            instructorTask,
            locationTask,
            groupTask,
            timesTask
        );

        Topics = topicTask.Result;
        Instructors = instructorTask.Result;
        Locations = locationTask.Result;
        Groups = groupTask.Result;
        Times = timesTask.Result;
    }

    private async Task<IReadOnlyCollection<TopicReadModel>> LoadTopics()
    {
        var command = new EntityIdentifiersQuery<Guid, TopicReadModel>(User, TopicIds);
        var result = await Mediator.Send(command);

        return result;
    }

    private async Task<IReadOnlyCollection<SessionCalendarModel>> LoadSessions()
    {
        var query = new SessionTopicQuery(User, TopicIds);
        var items = await Mediator.Send(query);

        return items;
    }

    private async Task<IReadOnlyCollection<MemberDropdownModel>> LoadInstructors()
    {
        var dropdownQuery = new MemberDropdownQuery(User, Tenant.Value.Id) { RoleId = Core.Data.Constants.Role.Instructor };
        var items = await Mediator.Send(dropdownQuery);

        return items;
    }

    private async Task<IReadOnlyCollection<LocationDropdownModel>> LoadLocations()
    {
        var dropdownQuery = new LocationDropdownQuery(User);
        var items = await Mediator.Send(dropdownQuery);

        return items;
    }

    private async Task<IReadOnlyCollection<GroupDropdownModel>> LoadGroups()
    {
        var dropdownQuery = new GroupDropdownQuery(User);
        var items = await Mediator.Send(dropdownQuery);

        return items;
    }

    private async Task<IReadOnlyCollection<SessionFrequentTimeModel>> LoadTimes()
    {
        var query = new SessionFrequentTimeQuery(User, Tenant.Value.Id);
        var items = await Mediator.Send(query);

        return items;
    }
}
