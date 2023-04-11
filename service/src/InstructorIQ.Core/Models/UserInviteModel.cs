namespace InstructorIQ.Core.Models;

public class UserInviteModel : UserAgentModel
{
    public Data.Entities.User User { get; set; }

    public string ReturnUrl { get; set; }
}
