using System;

using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'UserClaim'.
/// </summary>
public class UserClaim : IdentityUserClaim<Guid>
{
}
