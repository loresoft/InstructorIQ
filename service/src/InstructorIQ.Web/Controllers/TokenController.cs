using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstructorIQ.Web.Controllers
{
    [Route("api/Token")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(TokenError), 400)]
    [ProducesResponseType(typeof(ErrorModel), 500)]
    public class TokenController : Controller
    {

        [HttpPost("")]
        public async Task<IActionResult> Authenticate(CancellationToken cancellationToken, TokenRequest tokenRequest)
        {
            var remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return null;

        }
    }
}