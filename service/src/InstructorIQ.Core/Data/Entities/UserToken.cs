using System;
using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Data.Entities
{
    /// <summary>
    /// Entity class representing data for table 'UserToken'.
    /// </summary>
    public class UserToken : IdentityUserToken<Guid>
    {
    }
}