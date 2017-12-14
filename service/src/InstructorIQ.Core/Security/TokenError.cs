using System;
using Newtonsoft.Json;

namespace InstructorIQ.Core.Security
{
    public class TokenError
    {
        [JsonProperty(TokenConstants.Parameters.Error, NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty(TokenConstants.Parameters.ErrorDescription, NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDescription { get; set; }
    }
}