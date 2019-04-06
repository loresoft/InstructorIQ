namespace InstructorIQ.Core.Domain.Models
{
    public class MemberUpdateModel
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string DisplayName { get; set; }

        public bool IsGlobalAdministrator { get; set; }
    }
}
