using System;

namespace InstructorIQ.Core.Models;

public interface IUserAgentModel
{
    string UserAgent { get; set; }
    string Browser { get; set; }
    string OperatingSystem { get; set; }
    string DeviceFamily { get; set; }
    string DeviceBrand { get; set; }
    string DeviceModel { get; set; }
    string IpAddress { get; set; }
}
