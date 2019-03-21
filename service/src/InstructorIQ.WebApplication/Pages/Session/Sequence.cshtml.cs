using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Session
{
    public class SequenceModel : MediatorModelBase
    {
        public SequenceModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Selected = new List<int>();
            TopicIds = new List<Guid>();
        }

        [BindProperty(SupportsGet = true)]
        public List<Guid> TopicIds { get; set; }

        [BindProperty] public List<int> Selected { get; set; }

        public IReadOnlyCollection<TopicReadModel> Topics { get; set; }

        public IReadOnlyCollection<GroupSequenceModel> Sequences { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var topicsTask = LoadTopics();
            var groupsTask = LoadGroups();

            // load all in parallel
            await Task.WhenAll(
                topicsTask,
                groupsTask
            );

            Topics = topicsTask.Result;
            Sequences = groupsTask.Result;

            var title = Topics.Select(t => t.Title).ToDelimitedString("; ");

            // shared layout title
            ViewData["TopicTitle"] = $" - {title}";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Selected.Count == 0)
                return Page();

            var command = new SessionSequenceCreateCommand(User, TopicIds, Selected);
            var result = await Mediator.Send(command);

            return RedirectToPage("/session/bulk", new { TopicIds, tenant = TenantRoute });
        }

        private async Task<IReadOnlyCollection<TopicReadModel>> LoadTopics()
        {
            var command = new EntityIdentifiersQuery<Guid, TopicReadModel>(TopicIds, User);
            var result = await Mediator.Send(command);

            return result;
        }

        private async Task<IReadOnlyCollection<GroupSequenceModel>> LoadGroups()
        {
            var dropdownQuery = new GroupSequenceQuery(User);
            var items = await Mediator.Send(dropdownQuery);

            return items;
        }
    }
}