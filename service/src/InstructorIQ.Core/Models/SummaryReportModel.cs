using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstructorIQ.Core.Models;

public class SummaryReportModel
{
    [Required]
    public List<string> Recipients { get; set; } = new List<string>();

    [Required]
    public string ReplyToAddress { get; set; }
    public string ReplyToName { get; set; }

    [Required]
    public string Subject { get; set; }

    public string TextBody { get; set; }

    public string HtmlBody { get; set; }
}
