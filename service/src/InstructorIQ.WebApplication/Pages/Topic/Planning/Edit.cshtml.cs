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

namespace InstructorIQ.WebApplication.Pages.Topic.Planning;

[Authorize(Policy = UserPolicies.InstructorPolicy)]
public class EditModel : EntityIdentifierModelBase<TopicUpdateModel>
{
    public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var readCommand = new EntityIdentifierQuery<Guid, TopicUpdateModel>(User, Id);
        var updateModel = await Mediator.Send(readCommand);
        if (updateModel == null)
            return NotFound();

        // only update input fields
        await TryUpdateModelAsync(
            updateModel,
            nameof(Entity),
            p => p.LessonPlan
        );

        var updateCommand = new EntityUpdateCommand<Guid, TopicUpdateModel, TopicReadModel>(User, Id, updateModel);
        var result = await Mediator.Send(updateCommand);

        ShowAlert("Successfully saved topic");

        return RedirectToPage("/Topic/Planning/View", new { id = result.Id, tenant = TenantRoute });
    }
}
