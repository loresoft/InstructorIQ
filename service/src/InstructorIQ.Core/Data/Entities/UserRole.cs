using System;

using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'UserRole'.
/// </summary>
public class UserRole : IdentityUserRole<Guid>
{
}
