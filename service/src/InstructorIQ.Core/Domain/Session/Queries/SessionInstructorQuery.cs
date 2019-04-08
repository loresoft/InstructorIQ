using System;
using System.Collections.Generic;
using System.Security.Principal;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class SessionInstructorQuery : PrincipalQueryBase<IReadOnlyCollection<SessionInstructorModel>>
    {
        public SessionInstructorQuery(IPrincipal principal, Guid sessionId) : base(principal)
        {
            SessionId = sessionId;
        }

        public Guid SessionId { get;  }
    }
}