using System;

// ReSharper disable once CheckNamespace
namespace InstructorIQ.Core.Models
{
    public abstract class EmailModelBase : UserAgentModel, IEmailRecipient, IEmailReplyTo
    {
        public string RecipientName { get; set; }
        public string RecipientAddress { get; set; }

        public string ReplyToName { get; set; }
        public string ReplyToAddress { get; set; }
        
        public string Link { get; set; }
    }
}