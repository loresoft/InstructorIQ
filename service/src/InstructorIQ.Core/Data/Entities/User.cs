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
        public User()
        {
        }

        public User(string userName) : base(userName)
        {
        }

        public string GivenName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        public string SortName { get; set; } = string.Empty;

        public string JobTitle { get; set; }

        public Guid? LastTenantId { get; set; }

        public bool IsGlobalAdministrator { get; set; }
    }
}
