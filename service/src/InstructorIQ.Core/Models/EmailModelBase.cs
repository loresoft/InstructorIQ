// ReSharper disable once CheckNamespace

using System;

namespace InstructorIQ.Core.Models
{
    public abstract class EmailModelBase : IUserAgentModel
    {
        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public string Link { get; set; }

        public string UserAgent { get; set; }

        public string Browser { get; set; }
        public string OperatingSystem { get; set; }

        public string DeviceFamily { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }

        public string IpAddress { get; set; }
    }
}