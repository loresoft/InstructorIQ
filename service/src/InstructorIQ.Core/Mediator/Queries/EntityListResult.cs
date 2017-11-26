using System;
using System.Collections.Generic;
using InstructorIQ.Core.Mediator.Models;

namespace InstructorIQ.Core.Mediator.Queries
{
    public class EntityListResult<TReadModel>
        where TReadModel : EntityReadModel
    {
        public long Total { get; set; }

        public IReadOnlyCollection<TReadModel> Data { get; set; }
    }
}