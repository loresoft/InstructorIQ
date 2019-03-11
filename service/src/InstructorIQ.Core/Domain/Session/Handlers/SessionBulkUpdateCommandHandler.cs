using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EntityFrameworkCore.CommandQuery.Handlers;
using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Commands;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Models;
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

        protected override async Task<CommandCompleteModel> Process(SessionBulkUpdateCommand message, CancellationToken cancellationToken)
        {
            foreach (var updateModel in message.Models)
                await UpdateSession(updateModel, message.Principal?.Identity?.Name);

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
        }
    }
}