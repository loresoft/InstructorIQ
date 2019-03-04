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
    public class GroupDropdownQueryHandler : DataContextHandlerBase<InstructorIQContext, GroupDropdownQuery, IReadOnlyCollection<GroupDropdownModel>>
    {
        private readonly UserClaimManager _userClaimManager;

        public GroupDropdownQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<IReadOnlyCollection<GroupDropdownModel>> Process(GroupDropdownQuery message, CancellationToken cancellationToken)
        {
            var query = DataContext.Groups
                .AsNoTracking()
                .AsQueryable();

            var tenantString = _userClaimManager.GetTenantId(message.Principal);
            if (Guid.TryParse(tenantString, out var tenantId))
                query = query.Where(q => q.TenantId == tenantId);

            var result = await query
                .ProjectTo<GroupDropdownModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
