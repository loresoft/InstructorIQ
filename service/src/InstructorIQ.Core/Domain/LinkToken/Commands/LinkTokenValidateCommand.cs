using System;
using System.Security.Principal;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public class LinkTokenValidateCommand : PrincipalCommandBase<LinkTokenReadModel>
{
    public LinkTokenValidateCommand(IPrincipal principal, string token) : base(principal)
    {
        Token = token;
    }

    public string Token { get; }
}
