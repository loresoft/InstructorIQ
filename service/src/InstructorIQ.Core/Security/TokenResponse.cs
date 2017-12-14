using System;
using Newtonsoft.Json;

namespace InstructorIQ.Core.Security
{
    public class TokenResponse
    {
        [JsonProperty(TokenConstants.Parameters.AccessToken, NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        [JsonProperty(TokenConstants.Parameters.TokenType, NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; } = "bearer";

        [JsonProperty(TokenConstants.Parameters.ExpiresIn, NullValueHandling = NullValueHandling.Ignore)]
        public long ExpiresIn { get; set; }

        [JsonProperty(TokenConstants.Parameters.RefreshToken, NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; set; }
    }
}