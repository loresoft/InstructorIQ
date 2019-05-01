using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace InstructorIQ.WebApplication.Rewrite
{
    public class RedirectToNonWwwRule : IRule
    {
        public readonly int _statusCode;

        public RedirectToNonWwwRule(int statusCode)
        {
            _statusCode = statusCode;
        }

        public virtual void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            if (request.Host.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            if (!request.Host.Value.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            var hostString = new HostString(request.Host.Value.Substring(4));
            var newUrl = UriHelper.BuildAbsolute(request.Scheme, hostString, request.PathBase, request.Path, request.QueryString);

            var response = context.HttpContext.Response;
            response.StatusCode = _statusCode;
            response.Headers[HeaderNames.Location] = newUrl;

            context.Result = RuleResult.EndResponse;

            context.Logger?.LogInformation("Request redirected to non-www");
        }
    }
}
