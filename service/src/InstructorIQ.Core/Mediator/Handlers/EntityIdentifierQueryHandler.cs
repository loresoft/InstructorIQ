using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using MediatR;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityIdentifierQueryHandler<TEntity, TReadModel> : IAsyncRequestHandler<EntityIdentifierQuery<TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityIdentifierQueryHandler(InstructorIQContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TReadModel> Handle(EntityIdentifierQuery<TEntity, TReadModel> message)
        {
            var entity = await _context
                .FindAsync<TEntity>(message.Id)
                .ConfigureAwait(false);

            var model = _mapper.Map<TReadModel>(entity);

            return model;
        }
    }
}
