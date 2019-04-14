using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Extensions;
using MediatR.CommandQuery.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class TenantPagedQueryHandler : DataContextHandlerBase<InstructorIQContext, TenantPagedQuery, TenantPagedResult>
    {
        public TenantPagedQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper) : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<TenantPagedResult> Process(TenantPagedQuery request, CancellationToken cancellationToken)
        {
            var entityQuery = request.Query;
            var userName = request.Principal.Identity.Name;
            bool isGlobalAdministrator = request.Principal.IsInRole(Data.Constants.Role.GlobalAdministrator);

            // tenants that current user are members for
            var query = isGlobalAdministrator
                ? DataContext.Tenants
                : from t in DataContext.Tenants
                  where
                  (
                      from r in DataContext.TenantUserRoles
                      where r.UserName == userName
                      select r.TenantId
                  ).Contains(t.Id)
                  select t;


            // build query from filter
            query = query
                .AsNoTracking()
                .Filter(entityQuery.Filter);

            // add raw query
            if (!string.IsNullOrEmpty(entityQuery.Query))
                query = query.Where(entityQuery.Query);

            // get total for query
            var total = await query
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            // short circuit if total is zero
            if (total == 0)
                return new TenantPagedResult { Data = new List<TenantReadModel>() };

            // page the query and convert to read model
            var result = await query
                .Sort(entityQuery.Sort)
                .Page(entityQuery.Page, entityQuery.PageSize)
                .ProjectTo<TenantReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return new TenantPagedResult
            {
                Total = total,
                Data = result.AsReadOnly()
            };
        }
    }
}
