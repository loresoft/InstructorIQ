using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Mediator.Commands;
using InstructorIQ.Core.Mediator.Models;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Mediator.Handlers
{
    public class EntityCreateCommandHandler<TEntity, TCreateModel, TReadModel> : RequestHandlerBase<EntityCreateCommand<TEntity, TCreateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
        where TCreateModel : EntityCreateModel
        where TReadModel : EntityReadModel
    {
        private readonly InstructorIQContext _context;
        private readonly IMapper _mapper;

        public EntityCreateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<TReadModel> Process(EntityCreateCommand<TEntity, TCreateModel, TReadModel> message, CancellationToken cancellationToken)
        {
            // create new entity from model
            var entity = _mapper.Map<TEntity>(message.Model);

            var dbSet = _context
                .Set<TEntity>();

            // add to data set, id should be generated
            await dbSet
                .AddAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            // save to database
            await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // convert to read model
            var readModel = _mapper.Map<TReadModel>(entity);

            return readModel;
        }
    }
}