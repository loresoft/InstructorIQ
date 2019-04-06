using System.Collections.Generic;
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
    public class TenantDropdownQueryHandler : DataContextHandlerBase<InstructorIQContext, TenantDropdownQuery, IReadOnlyCollection<TenantDropdownModel>>
    {
        public TenantDropdownQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<IReadOnlyCollection<TenantDropdownModel>> Process(TenantDropdownQuery message, CancellationToken cancellationToken)
        {
            var result = await DataContext.Tenants
                .AsNoTracking()
                .OrderBy(q => q.Name)
                .ProjectTo<TenantDropdownModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
