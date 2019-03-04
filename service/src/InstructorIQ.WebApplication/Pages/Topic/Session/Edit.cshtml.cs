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

namespace InstructorIQ.WebApplication.Pages.Topic.Session
{
    public class EditModel : EntityIdentifierModelBase<SessionUpdateModel>
    {
        public EditModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public Guid TopicId { get; set; }

        [BindProperty(SupportsGet = true)]
        public TopicReadModel Topic { get; set; }

        [BindProperty]
        public IReadOnlyCollection<InstructorDropdownModel> Instructors { get; set; }

        [BindProperty]
        public IReadOnlyCollection<LocationDropdownModel> Locations { get; set; }

        [BindProperty]
        public IReadOnlyCollection<GroupDropdownModel> Groups { get; set; }


        public override async Task<IActionResult> OnGetAsync()
        {
            var loadTask = base.OnGetAsync();
            var loadTopicTask = LoadTopic();
            var instructorTask = LoadInstructors();
            var locationTask = LoadLocations();
            var groupTask = LoadGroups();

            // load all in parallel
            await Task.WhenAll(loadTopicTask, loadTask, instructorTask, locationTask, groupTask);

            Topic = loadTopicTask.Result;
            Instructors = instructorTask.Result;
            Locations = locationTask.Result;
            Groups = groupTask.Result;

            // shared layout title
            ViewData["TopicTitle"] = $" - {Topic.Title}";

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var readCommand = new EntityIdentifierQuery<Guid, SessionUpdateModel>(Id, User);
            var updateModel = await Mediator.Send(readCommand);
            if (updateModel == null)
                return NotFound();

            // only update input fields
            await TryUpdateModelAsync(
                updateModel,
                nameof(Entity),
                p => p.Note,
                p => p.StartTime,
                p => p.EndTime,
                p => p.LocationId,
                p => p.GroupId,
                p => p.LeadInstructorId
            );

            var updateCommand = new EntityUpdateCommand<Guid, SessionUpdateModel, SessionReadModel>(Id, updateModel, User);
            var result = await Mediator.Send(updateCommand);

            ShowAlert("Successfully saved topic session");

            return RedirectToPage("/Topic/Session/Edit", new { result.Id, TopicId });
        }

        public async Task<IActionResult> OnPostDeleteEntity()
        {
            var command = new EntityDeleteCommand<Guid, SessionReadModel>(Id, User);
            var result = await Mediator.Send(command);

            ShowAlert("Successfully deleted topic");

            return RedirectToPage("/Topic/Session/Index", new { Id = TopicId });
        }


        private async Task<TopicReadModel> LoadTopic()
        {
            var command = new EntityIdentifierQuery<Guid, TopicReadModel>(TopicId, User);
            var result = await Mediator.Send(command);

            return result;
        }

        private async Task<IReadOnlyCollection<InstructorDropdownModel>> LoadInstructors()
        {
            var dropdownQuery = new InstructorDropdownQuery(User);
            var items = await Mediator.Send(dropdownQuery);

            return items;
        }

        private async Task<IReadOnlyCollection<LocationDropdownModel>> LoadLocations()
        {
            var dropdownQuery = new LocationDropdownQuery(User);
            var items = await Mediator.Send(dropdownQuery);

            return items;
        }

        private async Task<IReadOnlyCollection<GroupDropdownModel>> LoadGroups()
        {
            var dropdownQuery = new GroupDropdownQuery(User);
            var items = await Mediator.Send(dropdownQuery);

            return items;
        }
    }
}