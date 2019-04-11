using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Security;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NaturalSort.Extension;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class SessionSequenceCreateCommandHandler : DataContextHandlerBase<InstructorIQContext, SessionSequenceCreateCommand, CommandCompleteModel>
    {
        private readonly UserClaimManager _userClaimManager;

        public SessionSequenceCreateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<CommandCompleteModel> Process(SessionSequenceCreateCommand request, CancellationToken cancellationToken)
        {
            var tenantId = _userClaimManager.GetRequiredTenantId(request.Principal);
            var identityName = request.Principal?.Identity?.Name;

            // load topic
            var topics = await DataContext.Topics
                .Where(g => g.TenantId == tenantId)
                .Where(g => request.TopicIds.Contains(g.Id))
                .ToListAsync(cancellationToken);

            // load groups by sequence
            var groups = await DataContext.Groups
                .Where(g => g.TenantId == tenantId)
                .Where(g => request.Sequences.Contains(g.Sequence))
                .ToListAsync(cancellationToken);

            var orderedGroups = groups
                .OrderBy(g => g.Sequence)
                .ThenBy(g => g.Name, StringComparer.OrdinalIgnoreCase.WithNaturalSort())
                .ToList();

            // create groups
            foreach (var topic in topics)
            {
                foreach (var group in orderedGroups)
                {
                    var session = new Session
                    {
                        TopicId = topic.Id,
                        LeadInstructorId = topic.LeadInstructorId,
                        TenantId = topic.TenantId,
                        GroupId = group.Id,
                        Created = DateTimeOffset.UtcNow,
                        CreatedBy = identityName,
                        Updated = DateTimeOffset.UtcNow,
                        UpdatedBy = identityName
                    };

                    DataContext.Sessions.Add(session);
                }
            }

            await DataContext.SaveChangesAsync(cancellationToken);

            return new CommandCompleteModel();
        }

    }
}