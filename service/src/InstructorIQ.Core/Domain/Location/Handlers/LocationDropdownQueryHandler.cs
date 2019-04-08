using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Security;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
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

        protected override async Task<IReadOnlyCollection<LocationDropdownModel>> Process(LocationDropdownQuery request, CancellationToken cancellationToken)
        {
            var tenantId = _userClaimManager.GetRequiredTenantId(request.Principal);

            var result = await DataContext.Locations
                .AsNoTracking()
                .Where(q => q.TenantId == tenantId)
                .OrderBy(q => q.Name)
                .ProjectTo<LocationDropdownModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
