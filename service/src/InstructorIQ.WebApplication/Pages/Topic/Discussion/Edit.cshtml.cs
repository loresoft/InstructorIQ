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
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Discussion
{
    [Authorize(Policy = UserPolicies.InstructorPolicy)]
    public class EditModel : EntityIdentifierModelBase<DiscussionUpdateModel>
    {
        public EditModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Guid TopicId { get; set; }

        public TopicReadModel Topic { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            var loadTask = base.OnGetAsync();
            var loadTopicTask = LoadTopic();

            // load all in parallel
            await Task.WhenAll(
                loadTopicTask,
                loadTask
            );

            Topic = loadTopicTask.Result;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, DiscussionUpdateModel>(User, Id);
            var updateModel = await Mediator.Send(readCommand);
            if (updateModel == null)
                return NotFound();

            // only update input fields
            await TryUpdateModelAsync(
                updateModel,
                nameof(Entity),
                p => p.Message
            );

            var updateCommand = new EntityUpdateCommand<Guid, DiscussionUpdateModel, DiscussionReadModel>(User, Id, updateModel);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved topic discussion message");

            return RedirectToPage("/Topic/Discussion/View", new { Id = TopicId, tenant = TenantRoute });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, DiscussionReadModel>(User, Id);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted discussion message");

            return RedirectToPage("/Topic/Discussion/View", new { Id = TopicId, tenant = TenantRoute });
        }

        private async Task<TopicReadModel> LoadTopic()
        {
            var command = new EntityIdentifierQuery<Guid, TopicReadModel>(User, TopicId);
            var result = await Mediator.Send(command);

            return result;
        }

    }
}