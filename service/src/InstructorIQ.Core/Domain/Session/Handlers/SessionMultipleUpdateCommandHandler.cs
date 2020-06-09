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
using InstructorIQ.Core.Security;
using MediatR.CommandQuery;
using MediatR.CommandQuery.EntityFrameworkCore.Handlers;
using MediatR.CommandQuery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers
{
    public class SessionMultipleUpdateCommandHandler : DataContextHandlerBase<InstructorIQContext, SessionMultipleUpdateCommand, CompleteModel>
    {
        public SessionMultipleUpdateCommandHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
            : base(loggerFactory, dataContext, mapper)
        {
        }

        protected override async Task<CompleteModel> Process(SessionMultipleUpdateCommand request, CancellationToken cancellationToken)
        {
            foreach (var updateModel in request.Models)
            {
                string userName = request.Principal?.Identity?.Name;

                await UpdateSession(updateModel, userName);
            }

            return new CompleteModel();
        }

        private async Task UpdateSession(SessionMultipleUpdateModel updateModel, string identityName)
        {
            var session = await DataContext.Sessions.FindAsync(updateModel.Id);
            if (session == null)
            {
                session = new Session
                {
                    Id = updateModel.Id,
                    TenantId = updateModel.TenantId,
                    TopicId = updateModel.TopicId,
                    Created = DateTimeOffset.UtcNow,
                    CreatedBy = identityName,
                };
                await DataContext.Sessions.AddAsync(session);
            }

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