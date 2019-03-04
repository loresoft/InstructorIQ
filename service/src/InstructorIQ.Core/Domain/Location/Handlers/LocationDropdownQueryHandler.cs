using System;
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
using InstructorIQ.Core.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class LocationDropdownQueryHandler : DataContextHandlerBase<InstructorIQContext, LocationDropdownQuery, IReadOnlyCollection<LocationDropdownModel>>
    {
        private readonly UserClaimManager _userClaimManager;

        public LocationDropdownQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<IReadOnlyCollection<LocationDropdownModel>> Process(LocationDropdownQuery message, CancellationToken cancellationToken)
        {
            var query = DataContext.Locations
                .AsNoTracking()
                .AsQueryable();

            var tenantString = _userClaimManager.GetTenantId(message.Principal);
            if (Guid.TryParse(tenantString, out var tenantId))
                query = query.Where(q => q.TenantId == tenantId);

            var result = await query
                .ProjectTo<LocationDropdownModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
