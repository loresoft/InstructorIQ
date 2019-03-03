using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Session
{
    public class IndexModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public IndexModel(IMediator mediator, ILoggerFactory loggerFactory)
            : base(mediator, loggerFactory)
        {
        }

        [BindProperty(Name = "p", SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        [BindProperty(Name = "z", SupportsGet = true)]
        public int PageSize { get; set; } = 20;

        [BindProperty(Name = "s", SupportsGet = true)]
        public string Sort { get; set; }

        [BindProperty(Name = "q", SupportsGet = true)]
        public string Query { get; set; }


        public long Total { get; set; }

        public IReadOnlyCollection<SessionReadModel> Items { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            // shared layout title
            ViewData["TopicTitle"] = $" - {Entity.Title}";

            var query = CreateQuery();
            var command = new EntityListQuery<SessionReadModel>(query, User);

            var result = await Mediator.Send(command).ConfigureAwait(false);
            Total = result.Total;
            Items = result.Data;

            return Page();
        }


        protected virtual EntityQuery CreateQuery()
        {
            var query = new EntityQuery(null, PageNumber, PageSize, Sort);

            if (string.IsNullOrWhiteSpace(Query))
                return query;

            query.Filter = CreateFilter();

            return query;
        }

        protected virtual EntityFilter CreateFilter()
        {
            var filter = new EntityFilter
            {
                Logic = EntityFilterLogic.Or,
                Filters = new[]
                {
                    new EntityFilter
                    {
                        Name = "Name",
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    }
                }
            };

            return filter;
        }

    }
}