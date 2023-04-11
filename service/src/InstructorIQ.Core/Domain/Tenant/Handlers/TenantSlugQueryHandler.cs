using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class TenantSlugQueryHandler : DataContextHandlerBase<InstructorIQContext, TenantSlugQuery, TenantReadModel>
{
    public TenantSlugQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
        : base(loggerFactory, dataContext, mapper)
    {
    }

    protected override async Task<TenantReadModel> Process(TenantSlugQuery request, CancellationToken cancellationToken)
    {
        var result = await DataContext.Tenants
            .AsNoTracking()
            .Where(q => q.Slug == request.Slug)
            .ProjectTo<TenantReadModel>(Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

        return result;
    }
}
