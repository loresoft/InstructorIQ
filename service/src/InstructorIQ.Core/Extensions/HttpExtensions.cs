using System;
using System.Collections.Generic;
using System.Text;
using InstructorIQ.Core.Models;
using Microsoft.AspNetCore.Http;
using UAParser;

namespace InstructorIQ.Core.Extensions
{
    public static class HttpExtensions
    {
        public static UserAgentModel UserAgent(this HttpRequest httpRequest)
        {
            var model = new UserAgentModel();

            if (httpRequest == null)
                return model;

            model.IpAddress = httpRequest.HttpContext.Connection.RemoteIpAddress.ToString();
            model.UserAgent = httpRequest.Headers["User-Agent"].ToString();

            if (string.IsNullOrEmpty(model.UserAgent))
                return model;

            var uaParser = Parser.GetDefault();
            var clientInfo = uaParser.Parse(model.UserAgent);

            model.Browser = clientInfo.UserAgent.Family;
            model.DeviceBrand = clientInfo.Device.Brand;
            model.DeviceFamily = clientInfo.Device.Family;
            model.DeviceModel = clientInfo.Device.Model;
            model.OperatingSystem = clientInfo.OS.Family;

            return model;
        }
    }
}
