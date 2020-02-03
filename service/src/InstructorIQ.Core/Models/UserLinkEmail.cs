namespace InstructorIQ.Core.Models
{
    public class UserLinkEmail: IEmailRecipient
    {
        public string RecipientName { get; set; }

        public string RecipientAddress { get; set; }

        public string ReplyToAddress { get; set; }

        public string ReplyToName { get; set; }

        public string Subject { get; set; }

        public string TextBody { get; set; }

        public string HtmlBody { get; set; }

        public string LinkUrl { get; set; }

        public string LinkText { get; set; }
    }
}