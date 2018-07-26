using System;
using InstructorIQ.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorModel), 422)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public abstract class MediatorControllerBase : ControllerBase
    {
        protected MediatorControllerBase(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }
    }
}