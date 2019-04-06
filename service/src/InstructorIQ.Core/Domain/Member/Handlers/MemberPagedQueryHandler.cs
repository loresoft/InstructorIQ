using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EntityFrameworkCore.CommandQuery.Extensions;
using EntityFrameworkCore.CommandQuery.Handlers;
using EntityFrameworkCore.CommandQuery.Queries;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberPagedQueryHandler : DataContextHandlerBase<InstructorIQContext, MemberPagedQuery, EntityPagedResult<MemberReadModel>>
    {
        public MemberPagedQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<EntityPagedResult<MemberReadModel>> Process(MemberPagedQuery message, CancellationToken cancellationToken)
        {
            var entityQuery = message.Query;

            // users that are members for tenent
            var query = from c in DataContext.Users
                        where
                        (
                            from t in DataContext.TenantUserRoles
                            where t.TenantId == message.TenantId
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
