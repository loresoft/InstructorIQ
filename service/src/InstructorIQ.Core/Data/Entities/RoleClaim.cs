using System;

using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'RoleClaim'.
/// </summary>
public class RoleClaim : IdentityRoleClaim<Guid>
{
}
