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

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberPagedQueryHandler : DataContextHandlerBase<InstructorIQContext, MemberPagedQuery, EntityPagedResult<MemberReadModel>>
    {
        public MemberPagedQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<EntityPagedResult<MemberReadModel>> Process(MemberPagedQuery request, CancellationToken cancellationToken)
        {
            var entityQuery = request.Query;

            // users that are members for tenant
            var query = from c in DataContext.Users
                        where
                        (
                            from t in DataContext.TenantUserRoles
                            where t.TenantId == request.TenantId
                            select t.UserName
                        ).Contains(c.UserName)
                        select c;


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
                return new EntityPagedResult<MemberReadModel> { Data = new List<MemberReadModel>() };

            // page the query and convert to read model
            var result = await query
                .Sort(entityQuery.Sort)
                .Page(entityQuery.Page, entityQuery.PageSize)
                .ProjectTo<MemberReadModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return new EntityPagedResult<MemberReadModel>
            {
                Total = total,
                Data = result.AsReadOnly()
            };

        }
    }
}
