using System;
using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record LinkTokenValidateCommand : PrincipalCommandBase<LinkTokenReadModel>
{
    public LinkTokenValidateCommand(ClaimsPrincipal principal, string token) : base(principal)
    {
        Token = token;
    }

    public string Token { get; }
}
