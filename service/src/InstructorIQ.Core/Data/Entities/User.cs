using System;
using System.Collections.Generic;
using MediatR.CommandQuery.Definitions;
using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'User'.
    /// </summary>
    public class User : IdentityUser<Guid>, IHaveIdentifier<Guid>
    {
        public User() : this(null)
        {
        }

        public User(string userName) : base(userName)
        {
            LeadTopics = new HashSet<Topic>();
            TopicInstructors = new HashSet<TopicInstructor>();
            LeadSessions = new HashSet<Session>();
            SessionInstructors = new HashSet<SessionInstructor>();
            TenantUserRoles = new HashSet<TenantUserRole>();
        }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string SortName { get; set; } = string.Empty;

        public string JobTitle { get; set; }

        public Guid? LastTenantId { get; set; }

        public bool IsGlobalAdministrator { get; set; }


        public virtual ICollection<Topic> LeadTopics { get; set; }

        public virtual ICollection<TopicInstructor> TopicInstructors { get; set; }

        public virtual ICollection<Session> LeadSessions { get; set; }

        public virtual ICollection<SessionInstructor> SessionInstructors { get; set; }

        public virtual ICollection<TenantUserRole> TenantUserRoles { get; set; }
    }
}
