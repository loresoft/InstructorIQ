using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Instructor
{
    public class EditModel : EntityIdentifierModelBase<InstructorUpdateModel>
    {
        public EditModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, InstructorUpdateModel>(Id, User);
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

            var updateCommand = new EntityUpdateCommand<Guid, InstructorUpdateModel, InstructorReadModel>(Id, updateModel, User);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved instructor");

            return RedirectToPage("/Instructor/Edit", new { id = result.Id });
        }

    }
}