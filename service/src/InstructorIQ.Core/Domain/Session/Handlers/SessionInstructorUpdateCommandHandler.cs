using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Data.Entities;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Models;
using MediatR.CommandQuery;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InstructorIQ.Core.Domain.Handlers
{
    public class SessionInstructorUpdateCommandHandler : DataContextHandlerBase<InstructorIQContext, SessionInstructorUpdateCommand, CommandCompleteModel>
    {
        public SessionInstructorUpdateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<CommandCompleteModel> Process(SessionInstructorUpdateCommand request, CancellationToken cancellationToken)
        {
            var sessionId = request.SessionId;
            var session = await DataContext.Sessions.FindAsync(sessionId);
            if (session == null)
                throw new DomainException(HttpStatusCode.NotFound, $"Session with id '{sessionId}' not found.");

            var identityName = request.Principal?.Identity?.Name;

            var existingInstructors = await DataContext.SessionInstructors
                .Where(s => s.SessionId == sessionId)
                .ToListAsync(cancellationToken);

            var updatedInstructors = request.Instructors;

            AddInstructors(existingInstructors, updatedInstructors, sessionId);
            RemoveInstructors(existingInstructors, updatedInstructors, sessionId);

            session.Updated = DateTimeOffset.UtcNow;
            session.UpdatedBy = identityName;

            await DataContext.SaveChangesAsync(cancellationToken);

            return new CommandCompleteModel();
        }

        private void RemoveInstructors(IReadOnlyCollection<SessionInstructor> existingInstructors, IEnumerable<Guid> updated, Guid sessionId)
        {
            if (existingInstructors.Count == 0)
                return;

            var existing = existingInstructors
                .Select(i => i.InstructorId)
                .ToList();

            var remove = existing
                .Except(updated)
                .ToList();

            if (remove.Count == 0)
                return;

            foreach (var instructorId in remove)
            {
                var sessionInstructor = existingInstructors
                    .FirstOrDefault(s => s.SessionId == sessionId && s.InstructorId == instructorId);

                if (sessionInstructor == null)
                    continue;

                DataContext.SessionInstructors.Remove(sessionInstructor);
            }
        }

        private void AddInstructors(IReadOnlyCollection<SessionInstructor> existingInstructors, IEnumerable<Guid> updated, Guid sessionId)
        {
            var existing = existingInstructors
                .Select(i => i.InstructorId)
                .ToList();

            var insert = updated
                .Except(existing)
                .ToList();

            if (insert.Count == 0)
                return;

            foreach (var instructorId in insert)
            {
                var sessionInstructor = new SessionInstructor
                {
                    SessionId = sessionId,
                    InstructorId = instructorId
                };

                DataContext.SessionInstructors.Add(sessionInstructor);
            }
        }
    }
}