using System.Collections.Generic;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstructorIQ.WebApplication.Pages.Group
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
            Sort = "Sequence";
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

        public IReadOnlyCollection<GroupReadModel> Data { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var query = CreateQuery();
            var command = new EntityListQuery<GroupReadModel>(query, User);

            var result = await _mediator.Send(command).ConfigureAwait(false);
            Total = result.Total;
            Data = result.Data;

            return Page();
        }


        private EntityQuery CreateQuery()
        {
            var query = new EntityQuery(null, PageNumber, PageSize, Sort);

            if (string.IsNullOrWhiteSpace(Query))
                return query;

            query.Filter = CreateFilter();

            return query;
        }

        private EntityFilter CreateFilter()
        {
            var filter = new EntityFilter
            {
                Logic = "or",
                Filters = new[]
                {
                    new EntityFilter
                    {
                        Name = "Name",
                        Value = Query,
                        Operator = "Contains"
                    },
                    new EntityFilter
                    {
                        Name = "Description",
                        Value = Query,
                        Operator = "Contains"
                    }
                }
            };

            return filter;
        }
    }

}