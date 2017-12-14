using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class EmailTemplateReadModel : EntityReadModel
    {
        #region Generated Properties
        public string Key { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public string ReplyToAddress { get; set; }
        public string ReplyToName { get; set; }
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public Guid? OrganizationId { get; set; }

        #endregion
    }
}