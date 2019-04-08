using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Extensions;
using InstructorIQ.Core.Security;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NaturalSort.Extension;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class GroupSequenceQueryHandler : DataContextHandlerBase<InstructorIQContext, GroupSequenceQuery, IReadOnlyCollection<GroupSequenceModel>>
    {
        private readonly UserClaimManager _userClaimManager;


        public GroupSequenceQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<IReadOnlyCollection<GroupSequenceModel>> Process(GroupSequenceQuery request, CancellationToken cancellationToken)
        {
            var tenantId = _userClaimManager.GetRequiredTenantId(request.Principal);

            var groups = await DataContext.Groups
                .AsNoTracking()
                .Where(q => q.TenantId == tenantId)
                .ToListAsync(cancellationToken);

            var grouping = groups.GroupBy(g => g.Sequence);

            var result = new List<GroupSequenceModel>();
            foreach (var group in grouping)
            {
                var sequenceModel = new GroupSequenceModel();
                sequenceModel.TenantId = tenantId;
                sequenceModel.Sequence = group.Key;

                sequenceModel.Name = group
                    .Select(g => g.Name)
                    .OrderBy(g => g, StringComparer.OrdinalIgnoreCase.WithNaturalSort())
                    .ToDelimitedString("; ");

                result.Add(sequenceModel);
            }

            return result
                .OrderBy(g => g.Sequence)
                .ToList();
        }
    }
}