using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class TenantSlugQueryHandler : DataContextHandlerBase<InstructorIQContext, TenantSlugQuery, TenantReadModel>
    {
        public TenantSlugQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<TenantReadModel> Process(TenantSlugQuery message, CancellationToken cancellationToken)
        {
            var result = await DataContext.Tenants
                .AsNoTracking()
                .Where(q => q.Slug == message.Slug)
                .ProjectTo<TenantReadModel>(Mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            return result;
        }
    }
}
