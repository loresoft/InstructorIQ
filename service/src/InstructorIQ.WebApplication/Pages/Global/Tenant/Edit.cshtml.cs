using System;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Global.Tenant
{
    [Authorize(Policy = UserPolicies.GlobalAdministratorPolicy)]
    public class EditModel : EntityIdentifierModelBase<TenantUpdateModel>
    {
        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, TenantUpdateModel>(Id, User);
            var updateModel = await Mediator.Send(readCommand);
            if (updateModel == null)
                return NotFound();

            // only update input fields
            await TryUpdateModelAsync(
                updateModel,
                nameof(Entity),
                p => p.Name,
                p => p.Description,
                p => p.Slug,
                p => p.City,
                p => p.StateProvince,
                p => p.TimeZone,
                p => p.DomainName
            );

            var updateCommand = new EntityUpdateCommand<Guid, TenantUpdateModel, TenantReadModel>(Id, updateModel, User);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved tenant");

            return RedirectToPage("/Global/Tenant/Edit", new { id = result.Id });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, TenantReadModel>(Id, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted tenant");

            return RedirectToPage("/Global/Tenant/Index");

        }

    }
}