using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Domain.Authentication.Commands;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [Route("api/Token")]
    public class TokenController : Controller
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("")]
        public async Task<IActionResult> AuthenticateForm(CancellationToken cancellationToken, TokenRequest tokenRequest)
        {
            try
            {
                var userAgent = Request.UserAgent();
                var command = new AuthenticateCommand(userAgent, tokenRequest);

                var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

                return Ok(result);
            }
            catch (AuthenticationException authenticationException)
            {
                var error = new TokenError
                {
                    Error = authenticationException.ErrorType,
                    ErrorDescription = authenticationException.Message
                };
                return BadRequest(error);
            }

        }

    }
}