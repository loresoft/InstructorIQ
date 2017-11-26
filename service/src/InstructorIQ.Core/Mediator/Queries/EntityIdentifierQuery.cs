using System;
using System.Security.Principal;
using System.Text;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Queries
{
    public class EntityIdentifierQuery<TEntity, TReadModel> : IRequest<TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        public IPrincipal Principal { get; set; }

        public Guid Id { get; set; }
    }
}
