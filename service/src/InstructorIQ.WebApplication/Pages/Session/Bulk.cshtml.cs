using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Session
{
    public class BulkModel : MediatorModelBase
    {
        public BulkModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
        }

        [BindProperty(SupportsGet = true)]
        public List<Guid> TopicIds { get; set; }

        [BindProperty]
        public List<SessionBulkUpdateModel> Sessions { get; set; }

        public IReadOnlyCollection<TopicReadModel> Topics { get; set; }

        public IReadOnlyCollection<InstructorDropdownModel> Instructors { get; set; }

        public IReadOnlyCollection<LocationDropdownModel> Locations { get; set; }

        public IReadOnlyCollection<GroupDropdownModel> Groups { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var topicsTask = LoadTopics();
            var sessionsTask = LoadSessions();
            var instructorTask = LoadInstructors();
            var locationTask = LoadLocations();
            var groupTask = LoadGroups();

            // load all in parallel
            await Task.WhenAll(
                sessionsTask,
                topicsTask,
                instructorTask,
                locationTask,
                groupTask
            );

            Topics = topicsTask.Result;
            Instructors = instructorTask.Result;
            Locations = locationTask.Result;
            Groups = groupTask.Result;

            var title = Topics.Select(t => t.Title).ToDelimitedString("; ");

            // shared layout title
            ViewData["TopicTitle"] = $" - {title}";

            // convert to bulk update
            Sessions = sessionsTask.Result
                .OrderBy(s => s.TopicTitle)
                .ThenBy(s => s.StartDate)
                .ThenBy(s => s.StartTime)
                .Select(i => new SessionBulkUpdateModel
                {
                    Id = i.Id,
                    StartDate = i.StartDate,
                    StartTime = i.StartTime,
                    EndDate = i.EndDate,
                    EndTime = i.EndTime,
                    GroupId = i.GroupId,
                    LeadInstructorId = i.LeadInstructorId,
                    LocationId = i.LocationId,
                    Note = i.Note,
                    TopicId = i.TopicId,
                    TopicTitle = i.TopicTitle
                })
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var bulkUpdateCommand = new SessionBulkUpdateCommand(User, Sessions);
            var result = await Mediator.Send(bulkUpdateCommand);

            ShowAlert("Successfully saved topic sessions");

            return RedirectToPage("/Topic/Index");
        }

        private async Task<IReadOnlyCollection<TopicReadModel>> LoadTopics()
        {
            var command = new EntityIdentifiersQuery<Guid, TopicReadModel>(TopicIds, User);
            var result = await Mediator.Send(command);

            return result;
        }

        private async Task<IReadOnlyCollection<SessionReadModel>> LoadSessions()
        {
            var query = new SessionTopicQuery(User, TopicIds);
            var items = await Mediator.Send(query);

            return items;
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