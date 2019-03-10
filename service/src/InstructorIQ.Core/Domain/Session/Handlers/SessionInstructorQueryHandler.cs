using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;
using InstructorIQ.Core.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class SessionInstructorQueryHandler : DataContextHandlerBase<InstructorIQContext, SessionInstructorQuery, IReadOnlyCollection<SessionInstructorModel>>
    {
        private readonly UserClaimManager _userClaimManager;

        public SessionInstructorQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper, UserClaimManager userClaimManager)
            : base(loggerFactory, dataContext, mapper)
        {
            _userClaimManager = userClaimManager;
        }

        protected override async Task<IReadOnlyCollection<SessionInstructorModel>> Process(SessionInstructorQuery message, CancellationToken cancellationToken)
        {
            var query = DataContext.SessionInstructors
                .AsNoTracking()
                .Where(s => s.SessionId == message.SessionId);

            var result = await query
                .Select(s => new SessionInstructorModel
                {
                    SessionId = s.SessionId,
                    InstructorId = s.InstructorId,
                    DisplayName = s.Instructor.DisplayName,
                    FamilyName = s.Instructor.FamilyName,
                    GivenName = s.Instructor.GivenName
                })
                .OrderBy(s => s.DisplayName)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}