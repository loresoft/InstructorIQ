using System;

namespace InstructorIQ.Core.Models;

public class UserPasswordlessEmail : EmailModelBase
{
    public int ExpireHours { get; set; } = 4;
}
