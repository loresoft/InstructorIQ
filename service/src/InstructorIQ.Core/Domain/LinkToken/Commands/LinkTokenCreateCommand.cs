using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Commands;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Commands
{
    public class LinkTokenCreateCommand : EntityModelCommand<LinkTokenCreateModel, LinkTokenReadModel>
    {
        public LinkTokenCreateCommand(IPrincipal principal, LinkTokenCreateModel model, string token)
            : base(principal, model)
        {
            Token = token;
        }

        public string Token { get; }
    }
}
