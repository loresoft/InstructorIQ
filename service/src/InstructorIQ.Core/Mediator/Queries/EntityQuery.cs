using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Mediator.Queries
{
    public class EntityQuery
    {
        public string Search { get; set; }

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public IEnumerable<EntitySort> Sort { get; set; }

        public EntityFilter Filter { get; set; }
    }
}