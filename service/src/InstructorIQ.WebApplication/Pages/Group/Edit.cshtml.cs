using System;
using System.Threading.Tasks;

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

namespace InstructorIQ.WebApplication.Pages.Group;

[Authorize(Policy = UserPolicies.AdministratorPolicy)]
public class EditModel : EntityIdentifierModelBase<GroupUpdateModel>
{
    public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var readCommand = new EntityIdentifierQuery<Guid, GroupUpdateModel>(User, Id);
        var updateModel = await Mediator.Send(readCommand);
        if (updateModel == null)
            return NotFound();

        // only update input fields
        await TryUpdateModelAsync(
            updateModel,
            nameof(Entity),
            p => p.Name,
            p => p.Description,
            p => p.Sequence
        );

        var updateCommand = new EntityUpdateCommand<Guid, GroupUpdateModel, GroupReadModel>(User, Id, updateModel);
        var result = await Mediator.Send(updateCommand);

        ShowAlert("Successfully saved group");

        return RedirectToPage("/Group/Edit", new { id = result.Id, tenant = TenantRoute });
    }

    public async Task<IActionResult> OnPostDeleteEntity()
    {
        var command = new EntityDeleteCommand<Guid, GroupReadModel>(User, Id);
        var result = await Mediator.Send(command);

        ShowAlert("Successfully deleted group");

        return RedirectToPage("/Group/Index", new { tenant = TenantRoute });

    }

}
