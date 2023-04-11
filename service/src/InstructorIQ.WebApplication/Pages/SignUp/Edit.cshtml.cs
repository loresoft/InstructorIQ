using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;

using MediatR;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.SignUp;

[Authorize(Policy = UserPolicies.AdministratorPolicy)]
public class EditModel : EntityIdentifierModelBase<SignUpUpdateModel>
{
    public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
    }

    [BindProperty]
    public List<SignUpTopicUpdateModel> SignUpTopics { get; set; }

    public IReadOnlyCollection<TopicReadModel> Topics { get; set; }

    public override async Task<IActionResult> OnGetAsync()
    {
        await base.OnGetAsync();

        Topics = await LoadTopics();
        SignUpTopics = await LoadSignUpTopics();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Topics = await LoadTopics();
            return Page();
        }

        var readCommand = new EntityIdentifierQuery<Guid, SignUpUpdateModel>(User, Id);
        var updateModel = await Mediator.Send(readCommand);
        if (updateModel == null)
            return NotFound();

        // only update input fields
        await TryUpdateModelAsync(
            updateModel,
            nameof(Entity),
            p => p.Name,
            p => p.Description
        );

        var updateCommand = new SignUpCommand(User, Id, updateModel, SignUpTopics);
        var result = await Mediator.Send(updateCommand);

        ShowAlert("Successfully saved instructor signup");

        return RedirectToPage("/signup/View", new { id = Id, tenant = TenantRoute });
    }

    public async Task<IActionResult> OnPostDeleteEntity()
    {
        var command = new EntityDeleteCommand<Guid, SignUpReadModel>(User, Id);
        var result = await Mediator.Send(command);

        ShowAlert("Successfully deleted instructor signup");

        return RedirectToPage("/signup/Index", new { tenant = TenantRoute });
    }

    private async Task<IReadOnlyCollection<TopicReadModel>> LoadTopics()
    {
        var filter = new EntityFilter
        {
            Name = nameof(TopicReadModel.CalendarYear),
            Value = DateTime.Now.Year,
            Operator = EntityFilterOperators.GreaterThanOrEqual
        };
        var select = new EntitySelect(filter);
        var command = new EntitySelectQuery<TopicReadModel>(User, select);
        var result = await Mediator.Send(command);

        return result
            .OrderBy(p => p.CalendarYear)
            .ThenBy(p => p.TargetMonth)
            .ThenBy(p => p.Title)
            .ToList();
    }

    private async Task<List<SignUpTopicUpdateModel>> LoadSignUpTopics()
    {
        var filter = new EntityFilter
        {
            Name = nameof(SignUpTopicUpdateModel.SignUpId),
            Value = Id,
            Operator = EntityFilterOperators.Equal
        };
        var select = new EntitySelect(filter);
        var command = new EntitySelectQuery<SignUpTopicUpdateModel>(User, select);
        var result = await Mediator.Send(command);

        return result
            .OrderBy(p => p.TopicCalendarYear)
            .ThenBy(p => p.TopicTargetMonth)
            .ThenBy(p => p.TopicTitle)
            .ToList();
    }
}
