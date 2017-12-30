using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityListQueryHandler<TEntity, TReadModel> : RequestHandlerBase<EntityListQuery<TEntity, TReadModel>, EntityListResult<TReadModel>>
        where TEntity : class
        where TReadModel : EntityReadModel
    {
        private static readonly Lazy<IReadOnlyCollection<TReadModel>> _emptyList = new Lazy<IReadOnlyCollection<TReadModel>>(() => new List<TReadModel>().AsReadOnly());

        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityListQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<EntityListResult<TReadModel>> Process(EntityListQuery<TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var entityQuery = message.Query;

            // build query from filter
            var query = _context
                .Set<TEntity>()
                .AsNoTracking()
                .Filter(entityQuery.Filter);

            // add raw query
            if (entityQuery.Query.HasValue())
                query = query.Where(entityQuery.Query);

            // get total for query
            var total = await query
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            // short circuit if total is zero
            if (total == 0)
                return new EntityListResult<TReadModel> { Data = _emptyList.Value };

            // page the query and convert to read model
            var result = await query
                .Sort(entityQuery.Sort)
                .Page(entityQuery.Page, entityQuery.PageSize)
                .ProjectTo<TReadModel>()
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return new EntityListResult<TReadModel>
            {
                Total = total,
                Data = result.AsReadOnly()
            };
        }



    }
}