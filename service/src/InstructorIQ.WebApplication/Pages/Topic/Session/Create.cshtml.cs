using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;

using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Session;

[Authorize(Policy = UserPolicies.AdministratorPolicy)]
public class CreateModel : EntityCreateModelBase<SessionCreateModel>
{
    public CreateModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {

    }


    [BindProperty(SupportsGet = true)]
    public Guid TopicId { get; set; }

    public TopicReadModel Topic { get; set; }

    public IReadOnlyCollection<MemberDropdownModel> Instructors { get; set; }

    public IReadOnlyCollection<LocationDropdownModel> Locations { get; set; }

    public IReadOnlyCollection<GroupDropdownModel> Groups { get; set; }


    public async Task<IActionResult> OnGetAsync()
    {
        var loadTopicTask = LoadTopic();
        var instructorTask = LoadInstructors();
        var locationTask = LoadLocations();
        var groupTask = LoadGroups();

        // load all in parallel
        await Task.WhenAll(loadTopicTask, instructorTask, locationTask, groupTask);

        Topic = loadTopicTask.Result;
        Instructors = instructorTask.Result;
        Locations = locationTask.Result;
        Groups = groupTask.Result;

        // shared layout title
        ViewData["TopicTitle"] = $" - {Topic.Title}";

        Entity.LeadInstructorId = Topic.LeadInstructorId;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var createModel = new SessionCreateModel
        {
            TopicId = TopicId
        };

        // only update input fields
        await TryUpdateModelAsync(
            createModel,
            nameof(Entity),
            p => p.Note,
            p => p.StartDate,
            p => p.StartTime,
            p => p.EndDate,
            p => p.EndTime,
            p => p.LocationId,
            p => p.GroupId,
            p => p.LeadInstructorId
        );

        var command = new EntityCreateCommand<SessionCreateModel, SessionReadModel>(User, createModel);
        var result = await Mediator.Send(command);

        ShowAlert("Successfully created topic session");

        return RedirectToPage("/Topic/Session/Edit", new { result.Id, TopicId, tenant = TenantRoute });
    }


    private async Task<TopicReadModel> LoadTopic()
    {
        var command = new EntityIdentifierQuery<Guid, TopicReadModel>(User, TopicId);
        var result = await Mediator.Send(command);

        return result;
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
}
