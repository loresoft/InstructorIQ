using System.Security.Claims;

using InstructorIQ.Core.Domain.Models;

using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands;

public record LinkTokenCreateCommand : EntityModelCommand<LinkTokenCreateModel, LinkTokenReadModel>
{
    public LinkTokenCreateCommand(ClaimsPrincipal principal, LinkTokenCreateModel model, string token)
        : base(principal, model)
    {
        Token = token;
    }

    public string Token { get; }
}
