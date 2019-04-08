using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    [Authorize(Policy = UserPolicies.InstructorPolicy)]
    public class EditModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty]
        public IReadOnlyCollection<InstructorDropdownModel> Instructors { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            var loadTask = base.OnGetAsync();
            var loadInstructorsTask = LoadInstructors();

            // load all in parallel
            await Task.WhenAll(
              loadTask,
              loadInstructorsTask
            );

            Instructors = loadInstructorsTask.Result;

            return Page();
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
                p => p.Title,
                p => p.Description,
                p => p.CalendarYear,
                p => p.TargetMonth,
                p => p.LeadInstructorId,
                p => p.IsRequired
            );

            var updateCommand = new EntityUpdateCommand<Guid, TopicUpdateModel, TopicReadModel>(User, Id, updateModel);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved topic");

            return RedirectToPage("/Topic/View", new { id = result.Id, tenant = TenantRoute });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, TopicReadModel>(User, Id);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted topic");

            return RedirectToPage("/Topic/Index", new { tenant = TenantRoute });

        }

        private async Task<IReadOnlyCollection<InstructorDropdownModel>> LoadInstructors()
        {
            var dropdownQuery = new InstructorDropdownQuery(User);
            var instructors = await Mediator.Send(dropdownQuery);

            return instructors;
        }


    }
}