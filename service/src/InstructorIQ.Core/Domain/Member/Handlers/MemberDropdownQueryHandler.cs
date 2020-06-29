using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class MemberDropdownQueryHandler
        : MemberQueryHandlerBase<MemberDropdownQuery, IReadOnlyCollection<MemberDropdownModel>>
    {
        public MemberDropdownQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<IReadOnlyCollection<MemberDropdownModel>> Process(MemberDropdownQuery request, CancellationToken cancellationToken)
        {
            // users that are members for tenant
            var query = UserQuery(request.TenantId, request.RoleId);

            var result = await query
                .AsNoTracking()
                .OrderBy(p => p.SortName)
                .ProjectTo<MemberDropdownModel>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return result;
        }
    }
}