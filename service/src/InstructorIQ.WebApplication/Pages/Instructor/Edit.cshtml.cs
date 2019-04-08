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

namespace InstructorIQ.WebApplication.Pages.Instructor
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class EditModel : EntityIdentifierModelBase<InstructorUpdateModel>
    {
        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, InstructorUpdateModel>(User, Id);
            var updateModel = await Mediator.Send(readCommand);
            if (updateModel == null)
                return NotFound();

            // only update input fields
            await TryUpdateModelAsync(
                updateModel,
                nameof(Entity),
                p => p.GivenName,
                p => p.FamilyName,
                p => p.DisplayName,
                p => p.JobTitle,
                p => p.EmailAddress,
                p => p.MobilePhone,
                p => p.BusinessPhone
            );

            var updateCommand = new EntityUpdateCommand<Guid, InstructorUpdateModel, InstructorReadModel>(User, Id, updateModel);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved instructor");

            return RedirectToPage("/Instructor/View", new { id = result.Id, tenant = TenantRoute });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, InstructorReadModel>(User, Id);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted instructor");

            return RedirectToPage("/Instructor/Index", new { tenant = TenantRoute });

        }

    }
}