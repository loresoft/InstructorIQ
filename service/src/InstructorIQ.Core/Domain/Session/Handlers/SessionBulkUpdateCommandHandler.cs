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
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class SessionBulkUpdateCommandHandler : DataContextHandlerBase<InstructorIQContext, SessionBulkUpdateCommand, CommandCompleteModel>
    {
        public SessionBulkUpdateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<CommandCompleteModel> Process(SessionBulkUpdateCommand request, CancellationToken cancellationToken)
        {
            foreach (var updateModel in request.Models)
                await UpdateSession(updateModel, request.Principal?.Identity?.Name);

            return new CommandCompleteModel();
        }

        private async Task UpdateSession(SessionBulkUpdateModel updateModel, string identityName)
        {
            var session = await DataContext.Sessions.FindAsync(updateModel.Id);
            if (session == null)
                throw new DomainException(HttpStatusCode.NotFound, $"Session with id '{updateModel.Id}' not found.");

            session.StartDate = updateModel.StartDate;
            session.StartTime = updateModel.StartTime;
            session.EndDate = updateModel.EndDate;
            session.EndTime = updateModel.EndTime;
            session.LocationId = updateModel.LocationId;
            session.GroupId = updateModel.GroupId;
            session.LeadInstructorId = updateModel.LeadInstructorId;
            session.Note = updateModel.Note;

            session.Updated = DateTimeOffset.UtcNow;
            session.UpdatedBy = identityName;

            await DataContext.SaveChangesAsync();
            
            // update instructors
            var sessionId = session.Id;
            var existingInstructors = await DataContext.SessionInstructors
                .Where(s => s.SessionId == sessionId)
                .ToListAsync();

            var updatedInstructors = updateModel.AdditionalInstructors ?? new List<Guid>();

            AddInstructors(existingInstructors, updatedInstructors, sessionId);
            RemoveInstructors(existingInstructors, updatedInstructors, sessionId);

            await DataContext.SaveChangesAsync();
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
            if (updated == null)
                return;

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