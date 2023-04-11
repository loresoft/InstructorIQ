using System;

namespace InstructorIQ.Core.Options;

public class SecurityOptions
{
    public const string ConfigurationName = "Security";

    public SecurityOptions()
    {
        PasswordlessTokenLifespan = TimeSpan.FromHours(4);
    }

    public TimeSpan PasswordlessTokenLifespan { get; set; }

}
