using System;
using System.Collections.Generic;
using System.Security.Principal;
using MediatR.CommandQuery.Queries;
using InstructorIQ.Core.Domain.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Queries
{
    public class GroupSequenceQuery : PrincipalQueryBase<IReadOnlyCollection<GroupSequenceModel>>
    {
        public GroupSequenceQuery(IPrincipal principal) : base(principal)
        {
        }
    }
}