using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Options
{
    public class HostingConfiguration
    {
        public string ClientDomain { get; set; }
        public string ServiceDomain { get; set; }
        public string ServiceEndpoint { get; set; }
    }
}
