using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Commands;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    public class EditModel : EntityEditModelBase<TopicUpdateModel>
    {
        public EditModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
        }

        [BindProperty]
        public IReadOnlyCollection<InstructorDropdownModel> Instructors { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            // shared layout title
            ViewData["TopicTitle"] = $" - {Entity.Title}";


            Instructors = await LoadInstructors();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, TopicUpdateModel>(Id, User);
            var updateModel = await Mediator.Send(readCommand);
            if (updateModel == null)
                return NotFound();

            // only update input fields
            await TryUpdateModelAsync(
                updateModel,
                nameof(Entity),
                p => p.Title,
                p => p.Description,
                p => p.Objectives,
                p => p.CalendarYear,
                p => p.TargetMonth,
                p => p.LeadInstructorId,
                p => p.IsRequired
            );

            var updateCommand = new EntityUpdateCommand<Guid, TopicUpdateModel, TopicReadModel>(Id, updateModel, User);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved topic");

            return RedirectToPage("/Topic/Edit", new { id = result.Id });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, TopicReadModel>(Id, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted topic");

            return RedirectToPage("/Topic/Index");

        }

        private async Task<IReadOnlyCollection<InstructorDropdownModel>> LoadInstructors()
        {
            var dropdownQuery = new InstructorDropdownQuery(User);
            var instructors = await Mediator.Send(dropdownQuery);

            return instructors;
        }


    }
}