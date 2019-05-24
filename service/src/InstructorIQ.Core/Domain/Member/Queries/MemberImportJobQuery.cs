using System;
using System.Security.Principal;
using InstructorIQ.Core.Domain.Models;
using MediatR.CommandQuery.Queries;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class MemberImportJobQuery : EntityIdentifierQuery<Guid, MemberImportJobModel>
    {
        public MemberImportJobQuery(IPrincipal principal, Guid id) : base(principal, id)
        {
        }
    }
}
