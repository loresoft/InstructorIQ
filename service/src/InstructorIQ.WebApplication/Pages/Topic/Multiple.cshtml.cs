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

        [BindProperty]
        public List<Guid> Selected { get; set; }

        [BindProperty]
        public List<TopicCreateModel> Topics { get; set; }

        public void OnGet()
        {
            Topics = new List<TopicCreateModel>
            {
                CreateTopic(),
                CreateTopic(),
                CreateTopic(),
                CreateTopic(),
                CreateTopic()
            };
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
                topic.TenantId = Tenant.Value.Id;
                topic.Description = topic.Title;
                topic.Created = DateTimeOffset.UtcNow;
                topic.CreatedBy = User.Identity.Name;
                topic.Updated = DateTimeOffset.UtcNow;
                topic.UpdatedBy = User.Identity.Name;
            }

            var command = new TopicCreateMultipleCommand(User, topics);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully created topics");

            return RedirectToPage("/Topic/Index", new { tenant = TenantRoute });
        }

        public IActionResult OnPostAdd()
        {
            Topics.Add(CreateTopic());
            return Page();
        }

        public IActionResult OnPostCopy()
        {
            if (Selected.Count == 0)
                return Page();

            foreach (var id in Selected)
            {
                var topic = Topics.FirstOrDefault(v => v.Id == id);
                if (topic == null)
                    continue;

                var createModel = new TopicCreateModel
                {
                    Id = Guid.NewGuid(),
                    Title = topic.Title,
                    CalendarYear = topic.CalendarYear,
                    TargetMonth = topic.TargetMonth
                };
                Topics.Add(createModel);
            }

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            if (Selected.Count == 0)
                return Page();

            Topics.RemoveAll(p => Selected.Contains(p.Id));
            Selected.Clear();

            return Page();
        }

        private TopicCreateModel CreateTopic(short? year = null)
        {
            return new TopicCreateModel
            {
                Id = Guid.NewGuid(),
                CalendarYear = year ?? (short)DateTime.Now.Year
            };
        }
    }
}