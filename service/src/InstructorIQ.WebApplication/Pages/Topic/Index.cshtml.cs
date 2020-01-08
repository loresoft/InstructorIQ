using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    public class IndexModel : EntityPagedModelBase<TopicListModel>
    {
        public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Sort = nameof(TopicReadModel.TargetMonth);
            Selected = new List<Guid>();
        }

        [BindProperty(Name = "year", SupportsGet = true)]
        public int? Year { get; set; }

        [BindProperty(Name = "month", SupportsGet = true)]
        public int? Month { get; set; }

        [BindProperty]
        public List<Guid> Selected { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            ReadHistory();

            var result = await base.OnGetAsync();

            WriteHistory();

            return result;
        }

        public IActionResult OnPostAddGroups()
        {
            if (Selected.Count == 0)
                return RedirectToPage();


            return RedirectToPage("/Session/Sequence", new { TopicIds = Selected, tenant = TenantRoute });
        }

        public IActionResult OnPostEditSessions()
        {
            if (Selected.Count == 0)
                return RedirectToPage();


            return RedirectToPage("/Session/Multiple", new { TopicIds = Selected, tenant = TenantRoute });
        }

        public IActionResult OnPostEditTopics()
        {
            if (Selected.Count == 0)
                return RedirectToPage();


            return RedirectToPage("/Topic/Multiple", new { TopicIds = Selected, tenant = TenantRoute });
        }


        protected override EntityQuery CreateQuery()
        {
            var query = new EntityQuery(null, PageNumber, PageSize, Sort);
            query.Filter = CreateFilter();

            return query;
        }

        protected override EntityFilter CreateFilter()
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


        private void WriteHistory()
        {
            Response.Cookies.Append("_topic_year", Year?.ToString() ?? string.Empty);
            Response.Cookies.Append("_topic_month", Month?.ToString() ?? string.Empty);
            Response.Cookies.Append("_topic_query", Query ?? string.Empty);
        }

        private void ReadHistory()
        {
            if (Year == null || Year == 0)
                Year = ReadCookieInt32("_topic_year") ?? DateTime.Now.Year;

            if (Month == null)
                Month = ReadCookieInt32("_topic_month");

            if (!Request.Query.ContainsKey("q") && Request.Cookies.TryGetValue("_topic_query", out var queryCookie))
                Query = queryCookie?.Trim();
        }

        private int? ReadCookieInt32(string name)
        {
            if (!Request.Cookies.TryGetValue(name, out var cookie))
                return null;

            if (!int.TryParse(cookie, out var value))
                return null;

            return value;
        }
    }
}