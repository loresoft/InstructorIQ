using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Security;
using MediatR;

namespace InstructorIQ.Core.Mediator.Commands
{
    public class AuthenticateCommand : IRequest<TokenResponse>
    {
        public AuthenticateCommand(TokenRequest tokenRequest)
        {
            TokenRequest = tokenRequest;
        }

        public TokenRequest TokenRequest { get; set; }
    }
}
