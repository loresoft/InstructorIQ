using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Models;
using InstructorIQ.Core.Mediator.Queries;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityIdentifierQueryHandler<TEntity, TReadModel> : RequestHandlerBase<EntityIdentifierQuery<TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityIdentifierQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<TReadModel> Process(EntityIdentifierQuery<TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var dbSet = _context
                .Set<TEntity>();

            var keyValue = new[] { message.Id };

            // find entity by message id
            var entity = await dbSet
                .FindAsync(keyValue, cancellationToken)
                .ConfigureAwait(false);

            if (entity == null)
                return null;

            // return read model
            var model = _mapper.Map<TReadModel>(entity);

            return model;
        }
    }
}
