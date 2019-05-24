using System;
using System.Collections.Generic;
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
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberExportQueryHandler : DataContextHandlerBase<InstructorIQContext, MemberExportQuery, IReadOnlyCollection<MemberImportModel>>
    {
        public MemberExportQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<IReadOnlyCollection<MemberImportModel>> Process(MemberExportQuery request, CancellationToken cancellationToken)
        {
            // users that are members for tenant
            var query = from c in DataContext.Users
                        where
                        (
                            from t in DataContext.TenantUserRoles
                            where t.TenantId == request.TenantId
                            select t.UserName
                        ).Contains(c.UserName)
                        select c;

            var result = await query
                .AsNoTracking()
                .OrderBy(p => p.DisplayName)
                .ProjectTo<MemberImportModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result;
        }
    }
}