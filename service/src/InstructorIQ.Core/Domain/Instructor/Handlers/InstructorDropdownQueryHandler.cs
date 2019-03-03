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
    public class InstructorDropdownQueryHandler : RequestHandlerBase<InstructorDropdownQuery, IReadOnlyCollection<InstructorDropdownModel>>
    {
        private readonly UserClaimManager _userClaimManager;

        protected InstructorIQContext DataContext { get; }
        protected IMapper Mapper { get; }

        public InstructorDropdownQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager) : base(loggerFactory)
        {
            DataContext = dataContext;
            Mapper = mapper;
            _userClaimManager = userClaimManager;
        }

        protected override async Task<IReadOnlyCollection<InstructorDropdownModel>> Process(InstructorDropdownQuery message, CancellationToken cancellationToken)
        {
            var query = DataContext.Instructors
                .AsNoTracking()
                .AsQueryable();

            var tenantString = _userClaimManager.GetTenantId(message.Principal);
            if (Guid.TryParse(tenantString, out var tenantId))
                query = query.Where(q => q.TenantId == tenantId);

            var result = await query
                .ProjectTo<InstructorDropdownModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
