using System;
using System.Collections.Generic;
using System.Text;
using EntityFrameworkCore.CommandQuery.Models;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Domain.Models
{
    public class EmailTemplateCreateModel : EntityCreateModel<Guid>
    {
        #region Generated Properties
        /// <summary>
        /// Gets or sets the property value for 'Key'.
        /// </summary>
        /// <value>
        /// The property value for 'Key'.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'FromAddress'.
        /// </summary>
        /// <value>
        /// The property value for 'FromAddress'.
        /// </value>
        public string FromAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'FromName'.
        /// </summary>
        /// <value>
        /// The property value for 'FromName'.
        /// </value>
        public string FromName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'ReplyToAddress'.
        /// </summary>
        /// <value>
        /// The property value for 'ReplyToAddress'.
        /// </value>
        public string ReplyToAddress { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'ReplyToName'.
        /// </summary>
        /// <value>
        /// The property value for 'ReplyToName'.
        /// </value>
        public string ReplyToName { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'Subject'.
        /// </summary>
        /// <value>
        /// The property value for 'Subject'.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'TextBody'.
        /// </summary>
        /// <value>
        /// The property value for 'TextBody'.
        /// </value>
        public string TextBody { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'HtmlBody'.
        /// </summary>
        /// <value>
        /// The property value for 'HtmlBody'.
        /// </value>
        public string HtmlBody { get; set; }

        /// <summary>
        /// Gets or sets the property value for 'OrganizationId'.
        /// </summary>
        /// <value>
        /// The property value for 'OrganizationId'.
        /// </value>
        public Guid? OrganizationId { get; set; }

        #endregion
    }
}