using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using MediatR.CommandQuery.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    public class ExportModel : ExportModelBase
    {
        public ExportModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Year = DateTime.Now.Year;
        }

        [BindProperty(Name = "year", SupportsGet = true)]
        public int? Year { get; set; }

        [BindProperty(Name = "month", SupportsGet = true)]
        public int? Month { get; set; }

        [BindProperty(Name = "q", SupportsGet = true)]
        public string Query { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var query = new EntitySelectQuery<TopicListModel>(User);
            query.Filter = CreateFilter();
            query.Sort = new List<EntitySort>
            {
                new EntitySort { Name = nameof(TopicListModel.CalendarYear) },
                new EntitySort { Name = nameof(TopicListModel.TargetMonth) },
                new EntitySort { Name = nameof(TopicListModel.Title) }
            };

            var topics = await Mediator.Send(query);

            var fileName = $"Topics-{DateTime.Now:yyyy-MM-dd-HH-mm-ss}.csv";

            return Export(topics, fileName);
        }


        private EntityFilter CreateFilter()
        {
            var filters = new List<EntityFilter>();
            var filter = new EntityFilter
            {
                Logic = EntityFilterLogic.And,
                Filters = filters
            };

            AddQueryFilter(filters);
            AddYearFilter(filters);
            AddMonthFilter(filters);

            return filter;
        }

        private void AddYearFilter(List<EntityFilter> filters)
        {
            if (Year == null || Year == 0)
                Year = DateTime.Now.Year;

            var yearFilter = new EntityFilter
            {
                Name = nameof(TopicReadModel.CalendarYear),
                Value = Year,
                Operator = EntityFilterOperators.Equal
            };
            filters.Add(yearFilter);
        }

        private void AddMonthFilter(List<EntityFilter> filters)
        {
            if (Month.HasValue == false || Month.Value <= 0)
                return;

            var monthFilter = new EntityFilter
            {
                Name = nameof(TopicReadModel.TargetMonth),
                Value = Month,
                Operator = EntityFilterOperators.Equal
            };
            filters.Add(monthFilter);
        }

        private void AddQueryFilter(List<EntityFilter> filters)
        {
            if (Query.IsNullOrWhiteSpace())
                return;

            var value = Query.Trim();
            var textFilter = new EntityFilter
            {
                Logic = EntityFilterLogic.Or,
                Filters = new[]
                {
                    new EntityFilter
                    {
                        Name = nameof(TopicReadModel.Title),
                        Value = value,
                        Operator = EntityFilterOperators.Contains
                    },
                    new EntityFilter
                    {
                        Name = nameof(TopicReadModel.Description),
                        Value = value,
                        Operator = EntityFilterOperators.Contains
                    }
                }
            };
            filters.Add(textFilter);
        }


    }
}