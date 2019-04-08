using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR.CommandQuery.Commands;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Planning
{
    public class EditModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Guid? TemplateId { get; set; }

        public IReadOnlyCollection<TemplateDropdownModel> Templates { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            var loadTask = base.OnGetAsync();
            var loadTemplatesTask = LoadTemplates();
            var loadTemplateTask = LoadTemplate();

            // load all in parallel
            await Task.WhenAll(
              loadTask,
              loadTemplatesTask,
              loadTemplateTask
            );

            Templates = loadTemplatesTask.Result;

            // apply template
            var template = loadTemplateTask.Result;
            if (template != null)
                Entity.LessonPlan = template.TemplateBody;

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
                p => p.LessonPlan
            );

            var updateCommand = new EntityUpdateCommand<Guid, TopicUpdateModel, TopicReadModel>(User, Id, updateModel);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved topic");

            return RedirectToPage("/Topic/Planning/View", new { id = result.Id, tenant = TenantRoute });
        }

        private async Task<TemplateReadModel> LoadTemplate()
        {
            if (TemplateId == null)
                return await Task.FromResult<TemplateReadModel>(null);

            var command = new EntityIdentifierQuery<Guid, TemplateReadModel>(User, TemplateId.Value);
            var result = await Mediator.Send(command);

            return result;
        }

        private async Task<IReadOnlyCollection<TemplateDropdownModel>> LoadTemplates()
        {
            var dropdownQuery = new TemplateDropdownQuery(User, Core.Data.Constants.TemplateType.LessonPlan);
            var templates = await Mediator.Send(dropdownQuery);

            return templates;
        }
    }
}