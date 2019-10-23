using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstructorIQ.Core.Services
{
    public class EmailMessage
    {
        [Required]
        public string To { get; set; }

        public string From { get; set; }

        [Required]
        public string ReplyTo { get; set; }

        [Required]
        public string Subject { get; set; }
        
        public string TextBody { get; set; }

        public string HtmlBody { get; set; }
    }
}
