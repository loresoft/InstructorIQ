using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityListQueryHandler<TEntity, TReadModel> : IAsyncRequestHandler<EntityListQuery<TEntity, TReadModel>, EntityListResult<TReadModel>>
        where TEntity : class
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityListQueryHandler(InstructorIQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EntityListResult<TReadModel>> Handle(EntityListQuery<TEntity, TReadModel> message)
        {
            var query = _context
                .Set<TEntity>()
                .AsNoTracking()
                .Filter(message.Filter);

            var total = await query
                .CountAsync()
                .ConfigureAwait(false);

            var result = await query
                .Sort(message.Sort)
                .Page(message.Page, message.PageSize)
                .ProjectTo<TReadModel>()
                .ToListAsync()
                .ConfigureAwait(false);

            return new EntityListResult<TReadModel>
            {
                Total = total,
                Data = result.AsReadOnly()
            };
        }



    }
}