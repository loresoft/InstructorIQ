using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using InstructorIQ.Core.Data;
using InstructorIQ.Core.Domain.Models;
using InstructorIQ.Core.Domain.Queries;

using MediatR.CommandQuery.EntityFrameworkCore.Handlers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Handlers;

public class SessionInstructorQueryHandler : DataContextHandlerBase<InstructorIQContext, SessionInstructorQuery, IReadOnlyCollection<SessionInstructorModel>>
{
    public SessionInstructorQueryHandler(ILoggerFactory loggerFactory, InstructorIQContext dataContext, IMapper mapper)
        : base(loggerFactory, dataContext, mapper)
    {

    }

    protected override async Task<IReadOnlyCollection<SessionInstructorModel>> Process(SessionInstructorQuery request, CancellationToken cancellationToken)
    {
        var query = DataContext.SessionInstructors
            .AsNoTracking()
            .Where(s => s.SessionId == request.SessionId);

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
