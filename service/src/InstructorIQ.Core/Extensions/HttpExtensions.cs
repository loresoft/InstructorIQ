using System;

using InstructorIQ.Core.Models;

using Microsoft.AspNetCore.Http;

using UAParser;

namespace InstructorIQ.Core.Extensions;

public static class HttpExtensions
{
    public static IUserAgentModel ReadUserAgent(this HttpRequest httpRequest)
    {
        var model = new UserAgentModel();
        return ReadUserAgent(httpRequest, model);
    }

    public static IUserAgentModel ReadUserAgent(this HttpRequest httpRequest, IUserAgentModel model)
    {
        if (httpRequest == null)
            return model;

        if (model == null)
            throw new ArgumentNullException(nameof(model));

        model.IpAddress = httpRequest.HttpContext.Connection.RemoteIpAddress.ToString();
        model.UserAgent = httpRequest.Headers["User-Agent"].ToString();

        if (string.IsNullOrEmpty(model.UserAgent))
            return model;

        var uaParser = Parser.GetDefault();
        var clientInfo = uaParser.Parse(model.UserAgent);

        model.Browser = clientInfo.UA.Family;
        model.DeviceBrand = clientInfo.Device.Brand;
        model.DeviceFamily = clientInfo.Device.Family;
        model.DeviceModel = clientInfo.Device.Model;
        model.OperatingSystem = clientInfo.OS.Family;

        return model;
    }
}
