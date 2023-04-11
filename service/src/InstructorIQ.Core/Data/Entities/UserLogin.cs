using System;

using Microsoft.AspNetCore.Identity;

namespace InstructorIQ.Core.Data.Entities;

/// <summary>
/// Entity class representing data for table 'UserLogin'.
/// </summary>
public class UserLogin : IdentityUserLogin<Guid>
{
}
