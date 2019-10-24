namespace InstructorIQ.Core.Models
{
    public interface IEmailRecipient
    {
        string RecipientName { get; set; }
        string RecipientAddress { get; set; }
    }
}