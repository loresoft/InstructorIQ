using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityChange.Extensions;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class MultipleModel : MediatorModelBase
    {
        public MultipleModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Selected = new List<Guid>();
        }

        [BindProperty(SupportsGet = true)]
        public List<Guid> TopicIds { get; set; }

        [BindProperty]
        public List<Guid> Selected { get; set; }

        [BindProperty]
        public List<TopicMultipleUpdateModel> Topics { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (TopicIds != null && TopicIds.Count != 0)
            {
                ViewData["Title"] = "Update Topics";
                Topics = await LoadTopics();
                return Page();
            }

            ViewData["Title"] = "Create Topics";
            Topics = new List<TopicMultipleUpdateModel>
            {
                CreateTopic(),
                CreateTopic(),
                CreateTopic(),
                CreateTopic(),
                CreateTopic()
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();


            var topics = Topics
                .Where(t => t.Title.HasValue())
                .ToList();

            if (topics.Count == 0)
            {
                ShowAlert("Enter a title for at least one topic.", "warning");
                return Page();
            }

            // ensure required data
            foreach (var topic in topics)
            {
                if (topic.TenantId == default)
                    topic.TenantId = Tenant.Value.Id;
                if (topic.Created == default)
                    topic.Created = DateTimeOffset.UtcNow;
                if (topic.CreatedBy.IsNullOrEmpty())
                    topic.CreatedBy = User.Identity.Name;

                topic.Updated = DateTimeOffset.UtcNow;
                topic.UpdatedBy = User.Identity.Name;
            }

            var command = new TopicMultipleUpdateCommand(User, topics);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully saved topics");

            return RedirectToPage("/Topic/Index", new { tenant = TenantRoute });
        }

        private async Task<List<TopicMultipleUpdateModel>> LoadTopics()
        {
            var command = new EntityIdentifiersQuery<Guid, TopicMultipleUpdateModel>(User, TopicIds);
            var result = await Mediator.Send(command);

            return result
                .OrderBy(p => p.CalendarYear)
                .ThenBy(p => p.TargetMonth)
                .ThenBy(p => p.Title)
                .ToList();
        }

        private TopicMultipleUpdateModel CreateTopic(short? year = null)
        {
            return new TopicMultipleUpdateModel
            {
                Id = Guid.NewGuid(),
                CalendarYear = year ?? (short)DateTime.Now.Year,
                TenantId = Tenant.Value.Id,
                Created = DateTimeOffset.UtcNow,
                CreatedBy = User.Identity.Name
            };
        }
    }
}