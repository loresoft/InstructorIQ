using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Attendance
{
    public class TopicModel : EntityPagedModelBase<AttendanceReadModel>
    {
        public TopicModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Year = DateTime.Now.Year;
        }



        [BindProperty(Name = "year", SupportsGet = true)]
        public int? Year { get; set; }

        [BindProperty(Name = "topicId", SupportsGet = true)]
        public Guid? TopicId { get; set; }

        public IReadOnlyCollection<TopicDropdownModel> Topics { get; set; }


        public override async Task<IActionResult> OnGetAsync()
        {
            var loadTask = base.OnGetAsync();
            var loadTopicsTask = LoadTopics();

            // load all in parallel
            await Task.WhenAll(
                loadTask,
                loadTopicsTask
            );

            Topics = loadTopicsTask.Result;

            return Page();
        }


        private async Task<IReadOnlyCollection<TopicDropdownModel>> LoadTopics()
        {
            var dropdownQuery = new EntitySelectQuery<TopicDropdownModel>(User);

            if (Year.HasValue)
            {
                var filter = new EntityFilter();
                filter.Name = nameof(Core.Data.Entities.Topic.CalendarYear);
                filter.Value = Year.Value;

                dropdownQuery.Filter = filter;
            }

            var topics = await Mediator.Send(dropdownQuery);

            return topics;
        }

    }
}