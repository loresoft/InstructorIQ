using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.WebApplication.Controllers;

[ApiController]
[Produces("application/json")]
public abstract class MediatorControllerBase : ControllerBase
{
    protected MediatorControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }

    public IMediator Mediator { get; }
}
