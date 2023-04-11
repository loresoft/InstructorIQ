using System;

namespace InstructorIQ.Core.Models;

public class UserInviteEmail : EmailModelBase
{
    public string TenantName { get; set; }

    public string SenderName { get; set; }
    public string SenderEmail { get; set; }
}
