using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Options
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public bool UseSSL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FromName { get; set; }

        public string FromAddress { get; set; }
    }
}
