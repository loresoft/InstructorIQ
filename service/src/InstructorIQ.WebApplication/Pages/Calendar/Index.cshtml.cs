using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Calendar
{
    public class IndexModel : MediatorModelBase
    {
        public IndexModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
            : base(tenant, mediator, loggerFactory)
        {
        }

        public void OnGet()
        {

        }
    }
}