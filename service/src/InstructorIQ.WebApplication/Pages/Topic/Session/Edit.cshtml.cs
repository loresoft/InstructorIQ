using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Commands;
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
public class EditModel : EntityIdentifierModelBase<SessionUpdateModel>
{
    public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
        AdditionalInstructors = new List<Guid>();
    }

    [BindProperty(SupportsGet = true)]
    public Guid TopicId { get; set; }

    [BindProperty]
    public List<Guid> AdditionalInstructors { get; set; }

    public TopicReadModel Topic { get; set; }

    public IReadOnlyCollection<MemberDropdownModel> Instructors { get; set; }

    public IReadOnlyCollection<LocationDropdownModel> Locations { get; set; }

    public IReadOnlyCollection<GroupDropdownModel> Groups { get; set; }


    public override async Task<IActionResult> OnGetAsync()
    {
        var loadTask = base.OnGetAsync();
        var loadTopicTask = LoadTopic();
        var instructorTask = LoadInstructors();
        var additionalTask = LoadAdditionalInstructors();
        var locationTask = LoadLocations();
        var groupTask = LoadGroups();

        // load all in parallel
        await Task.WhenAll(
            loadTopicTask,
            loadTask,
            instructorTask,
            additionalTask,
            locationTask,
            groupTask
        );

        Topic = loadTopicTask.Result;
        Instructors = instructorTask.Result;
        Locations = locationTask.Result;
        Groups = groupTask.Result;

        AdditionalInstructors = additionalTask.Result
            .Select(i => i.InstructorId)
            .ToList();

        // shared layout title
        ViewData["TopicTitle"] = $" - {Topic.Title}";

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var readCommand = new EntityIdentifierQuery<Guid, SessionUpdateModel>(User, Id);
        var updateModel = await Mediator.Send(readCommand);
        if (updateModel == null)
            return NotFound();

        // only update input fields
        await TryUpdateModelAsync(
            updateModel,
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

        var updateCommand = new EntityUpdateCommand<Guid, SessionUpdateModel, SessionReadModel>(User, Id, updateModel);
        var result = await Mediator.Send(updateCommand);

        var instructorCommand = new SessionInstructorUpdateCommand(User, Id, AdditionalInstructors);
        await Mediator.Send(instructorCommand);

        ShowAlert("Successfully saved topic session");

        return RedirectToPage("/Topic/Session/View", new { result.Id, TopicId, tenant = TenantRoute });
    }

    public async Task<IActionResult> OnPostDeleteEntity()
    {
        var command = new EntityDeleteCommand<Guid, SessionReadModel>(User, Id);
        var result = await Mediator.Send(command);

        ShowAlert("Successfully deleted topic");

        return RedirectToPage("/Topic/Session/Index", new { Id = TopicId, tenant = TenantRoute });
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

    private async Task<IReadOnlyCollection<SessionInstructorModel>> LoadAdditionalInstructors()
    {
        var dropdownQuery = new SessionInstructorQuery(User, Id);
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
