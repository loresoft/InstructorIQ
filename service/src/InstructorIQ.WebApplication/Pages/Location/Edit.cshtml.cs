using System;
using System.Threading.Tasks;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Location
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class EditModel : EntityIdentifierModelBase<LocationUpdateModel>
    {
        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, LocationUpdateModel>(User, Id);
            var updateModel = await Mediator.Send(readCommand);
            if (updateModel == null)
                return NotFound();

            // only update input fields
            await TryUpdateModelAsync(
                updateModel,
                nameof(Entity),
                p => p.Name,
                p => p.Description,
                p => p.AddressLine1,
                p => p.City,
                p => p.StateProvince,
                p => p.PostalCode
            );

            var updateCommand = new EntityUpdateCommand<Guid, LocationUpdateModel, LocationReadModel>(User, Id, updateModel);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved location");

            return RedirectToPage("/Location/Edit", new { id = result.Id, tenant = TenantRoute });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, LocationReadModel>(User, Id);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted location");

            return RedirectToPage("/Location/Index", new { tenant = TenantRoute });

        }

    }
}