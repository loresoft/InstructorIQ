using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Topic.Session
{
    public class IndexModel : EntityIdentifierModelBase<TopicUpdateModel>
    {
        public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
            Sort = nameof(SessionReadModel.StartDate);
        }

        [BindProperty(Name = "s", SupportsGet = true)]
        public string Sort { get; set; }

        public IReadOnlyCollection<SessionReadModel> Items { get; set; }

        public override async Task<IActionResult> OnGetAsync()
        {
            await base.OnGetAsync();

            var query = new SessionTopicQuery(User, Id);
            var result = await Mediator.Send(query);

            Items = result
                .OrderBy(r => r.StartDate)
                .ThenBy(r => r.StartTime)
                .ToList();

            return Page();
        }
    }
}