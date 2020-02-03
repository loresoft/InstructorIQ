using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstructorIQ.Core.Models
{
    public class UserLinkModel
    {
        [Required]
        public List<string> Recipients { get; set; } = new List<string>();

        public string ReplyToName { get; set; }

        public string ReplyToAddress { get; set; }

        [Required]
        public string Subject { get; set; }

        public string TextBody { get; set; }

        public string HtmlBody { get; set; }

        public string LinkUrl { get; set; }

        public string LinkText { get; set; }
    }
}