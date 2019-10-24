using System.ComponentModel.DataAnnotations;

namespace InstructorIQ.Core.Models
{
    public class SummaryReportEmail : IEmailRecipient
    {
        [Required]
        public string RecipientAddress { get; set; }
        public string RecipientName { get; set; }
        
        [Required]
        public string ReplyToAddress { get; set; }
        public string ReplyToName { get; set; }
        
        [Required]
        public string Subject { get; set; }
        
        public string TextBody { get; set; }

        public string HtmlBody { get; set; }
    }
}
