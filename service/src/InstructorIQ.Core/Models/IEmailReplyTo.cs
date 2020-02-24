namespace InstructorIQ.Core.Models
{
    public interface IEmailReplyTo
    {
        string ReplyToName { get; set; }
        string ReplyToAddress { get; set; }
    }
}