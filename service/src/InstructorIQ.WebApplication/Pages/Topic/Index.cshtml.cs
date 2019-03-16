using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic
{
    public class IndexModel : EntityListModelBase<TopicReadModel>
    {
        public IndexModel(IMediator mediator, ILoggerFactory loggerFactory) : base(mediator, loggerFactory)
        {
            Sort = nameof(TopicReadModel.TargetMonth);
            Selected = new List<Guid>();
        }

        [BindProperty]
        public List<Guid> Selected { get; set; }

        public IActionResult OnPostAddGroups()
        {
            if (Selected.Count == 0)
                return RedirectToPage();


            return RedirectToPage("/Session/Sequence", new { TopicIds = Selected });
        }

        public IActionResult OnPostBulkEdit()
        {
            if (Selected.Count == 0)
                return RedirectToPage();


            return RedirectToPage("/Session/Bulk", new { TopicIds = Selected });
        }

        protected override EntityFilter CreateFilter()
        {
            var filter = new EntityFilter
            {
                Logic = EntityFilterLogic.Or,
                Filters = new[]
                {
                    new EntityFilter
                    {
                        Name = nameof(TopicReadModel.Title),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    },
                    new EntityFilter
                    {
                        Name = nameof(TopicReadModel.Description),
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    }
                }
            };

            return filter;
        }
    }
}