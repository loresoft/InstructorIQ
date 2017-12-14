using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Data.Entities
{
    public partial class RefreshToken
    {
        public RefreshToken()
        {
            Issued = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public string TokenHashed { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string ClientId { get; set; }
        public string ProtectedTicket { get; set; }
        public DateTimeOffset Issued { get; set; }
        public DateTimeOffset? Expires { get; set; }

        public virtual User User { get; set; }
    }
}