using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class EmailDelivery
    {
        public EmailDelivery()
        {
            Attempts = 0;
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
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
        public Byte[] MimeMessage { get; set; }
        public Guid? OrganizationId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }

        public virtual Organization Organization { get; set; }
    }
}