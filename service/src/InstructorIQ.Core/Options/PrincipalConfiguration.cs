using System;

namespace InstructorIQ.Core.Options
{
    public class PrincipalConfiguration
    {
        public string AudienceId { get; set; }
        public string AudienceSecret { get; set; }
        public TimeSpan TokenExpire { get; set; } = TimeSpan.FromMinutes(30);
        public TimeSpan RefreshExpire { get; set; } = TimeSpan.FromDays(30);
    }
}