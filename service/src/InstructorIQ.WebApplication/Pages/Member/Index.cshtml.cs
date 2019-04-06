using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.Core.Security;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Member
{
    [Authorize(Policy = UserPolicies.AdministratorPolicy)]
    public class IndexModel : MediatorModelBase
    {
        private readonly UserManager<Core.Data.Entities.User> _userManager;

        public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory, UserManager<Core.Data.Entities.User> userManager)
            : base(tenant, mediator, loggerFactory)
        {
            _userManager = userManager;
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

        public IReadOnlyCollection<MemberReadModel> Items { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            var query = CreateQuery();
            var command = new MemberPagedQuery(query, Tenant.Value.Id, User);

            var result = await Mediator.Send(command);
            Total = result.Total;
            Items = result.Data;

            return Page();
        }


        protected EntityQuery CreateQuery()
        {
            var query = new EntityQuery(null, PageNumber, PageSize, Sort);

            if (string.IsNullOrWhiteSpace(Query))
                return query;

            query.Filter = CreateFilter();

            return query;
        }

        protected EntityFilter CreateFilter()
        {
            var filter = new EntityFilter
            {
                Logic = EntityFilterLogic.Or,
                Filters = new[]
                {
                    new EntityFilter
                    {
                        Name = "DisplayName",
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    },
                    new EntityFilter
                    {
                        Name = "Email",
                        Value = Query,
                        Operator = EntityFilterOperators.Contains
                    }
                }
            };

            return filter;
        }
    }
}