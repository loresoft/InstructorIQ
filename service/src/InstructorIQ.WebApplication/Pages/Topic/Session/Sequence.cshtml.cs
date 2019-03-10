using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Session
{
    public class SequenceModel : MediatorModelBase
    {
        public SequenceModel(IMediator mediator, ILoggerFactory loggerFactory) : base(mediator, loggerFactory)
        {
            Selected = new List<int>();
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public List<int> Selected { get; set; }

        public TopicReadModel Topic { get; set; }

        public IReadOnlyCollection<GroupSequenceModel> Sequences { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var loadTopicTask = LoadTopic();
            var groupTask = LoadGroups();

            // load all in parallel
            await Task.WhenAll(
                loadTopicTask,
                groupTask
            );

            Topic = loadTopicTask.Result;
            Sequences = groupTask.Result;

            // shared layout title
            ViewData["TopicTitle"] = $" - {Topic.Title}";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Selected.Count == 0)
                return Page();

            var command = new SessionSequenceCreateCommand(User, Id, Selected);
            var result = await Mediator.Send(command);

            return RedirectToPage("/topic/session/bulk", new { Id });
        }

        private async Task<TopicReadModel> LoadTopic()
        {
            var command = new EntityIdentifierQuery<Guid, TopicReadModel>(Id, User);
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