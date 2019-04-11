using InstructorIQ.Core.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class UserPasswordlessEmail : EmailModelBase
    {
        public string LoginLink { get; set; }

        public UserAgentModel UserAgent { get; set; }
    }
}