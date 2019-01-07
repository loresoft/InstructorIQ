using System;
using InstructorIQ.Core.Models;
using InstructorIQ.Core.Security;
using MediatR;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class AuthenticateCommand : IRequest<TokenResponse>
    {
        public AuthenticateCommand(UserAgentModel userAgent, TokenRequest tokenRequest)
        {
            UserAgent = userAgent;
            TokenRequest = tokenRequest;
        }

        public TokenRequest TokenRequest { get; set; }

        public UserAgentModel UserAgent { get; set; }
    }
}
