using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class EmailDeliveryCreateModel : EntityCreateModel
    {
        #region Generated Properties
        public bool IsProcessing { get; set; }
        public bool IsDelivered { get; set; }
        public DateTimeOffset? Delivered { get; set; }
        public int Attempts { get; set; }
        public DateTimeOffset? LastAttempt { get; set; }
        public DateTimeOffset? NextAttempt { get; set; }
        public string SmtpLog { get; set; }
        public string Error { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string MimeMessage { get; set; }
        public Guid? OrganizationId { get; set; }

        #endregion
    }
}