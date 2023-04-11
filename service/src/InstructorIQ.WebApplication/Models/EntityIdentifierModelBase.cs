using System;
using System.Threading.Tasks;

using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Multitenancy;

using MediatR;
using MediatR.CommandQuery.Queries;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.WebApplication.Models;

public abstract class EntityIdentifierModelBase<TModel> : MediatorModelBase
    where TModel : new()
{
    protected EntityIdentifierModelBase(ITenant<TenantReadModel> tenant, IMediator mediator, ILoggerFactory loggerFactory)
        : base(tenant, mediator, loggerFactory)
    {
        Entity = new TModel();
    }

    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public TModel Entity { get; set; }


    public virtual async Task<IActionResult> OnGetAsync()
    {
        var command = new EntityIdentifierQuery<Guid, TModel>(User, Id);

        var result = await Mediator.Send(command);
        if (result == null)
            return NotFound();

        Entity = result;

        return Page();
    }
}
