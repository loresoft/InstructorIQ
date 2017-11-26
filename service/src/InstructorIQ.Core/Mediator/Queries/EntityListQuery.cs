using System;
using System.Collections.Generic;
using InstructorIQ.Core.Mediator.Models;
using MediatR;

namespace InstructorIQ.Core.Mediator.Queries
{
    public class EntityListQuery<TEntity, TReadModel> : IRequest<EntityListResult<TReadModel>>
        where TEntity : class
        where TReadModel : EntityReadModel
    {
        public string Search { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public IEnumerable<EntitySort> Sort { get; set; }

        public EntityFilter Filter { get; set; }
    }
}