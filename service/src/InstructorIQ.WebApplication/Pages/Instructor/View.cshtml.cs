using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;
using InstructorIQ.WebApplication.Models;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Pages.Instructor;

[Authorize]
public class ViewModel : EntityIdentifierModelBase<MemberReadModel>
{
    public ViewModel(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
    }
}
