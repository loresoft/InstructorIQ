using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Mediator.Models
{
    public class UserLoginReadModel : EntityReadModel
    {
        #region Generated Properties
        public Guid? UserId { get; set; }
        public string EmailAddress { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }
        public string OperatingSystem { get; set; }
        public string DeviceFamily { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }
        public string IpAddress { get; set; }
        public bool IsSuccessful { get; set; }
        public string FailureMessage { get; set; }

        #endregion
    }
}