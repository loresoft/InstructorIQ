using System;

namespace InstructorIQ.Core.Options
{
    public class SecurityOptions
    {
        public SecurityOptions()
        {
            PasswordlessTokenLifespan = TimeSpan.FromHours(4);
        }

        public TimeSpan PasswordlessTokenLifespan { get; set; }

    }
}
