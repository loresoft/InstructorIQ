using System;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class EmailDeliveryReadModel : EntityReadModel<Guid>
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
        public Byte[] MimeMessage { get; set; }
        public Guid? OrganizationId { get; set; }

        #endregion
    }
}