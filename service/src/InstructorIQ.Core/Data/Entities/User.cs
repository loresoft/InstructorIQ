using System;
using System.Collections.Generic;
using EntityFrameworkCore.CommandQuery.Definitions;
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

        public string DisplayName { get; set; } = string.Empty;
    }
}
