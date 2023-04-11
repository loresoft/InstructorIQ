using System;

namespace InstructorIQ.Core.Models;

public class UserResetPasswordEmail : EmailModelBase
{
    public int ExpireHours { get; set; } = 24;
}
