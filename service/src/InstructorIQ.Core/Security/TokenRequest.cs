using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InstructorIQ.Core.Security
{
    public class TokenRequest
    {
        [ModelBinder(Name = TokenConstants.Parameters.GrantType)]
        [JsonProperty(TokenConstants.Parameters.GrantType, NullValueHandling = NullValueHandling.Ignore)]
        public string GrantType { get; set; }

        [ModelBinder(Name = TokenConstants.Parameters.ClientId)]
        [JsonProperty(TokenConstants.Parameters.ClientId, NullValueHandling = NullValueHandling.Ignore)]
        public string ClientId { get; set; }

        [ModelBinder(Name = TokenConstants.Parameters.Username)]
        [JsonProperty(TokenConstants.Parameters.Username, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [ModelBinder(Name = TokenConstants.Parameters.Password)]
        [JsonProperty(TokenConstants.Parameters.Password, NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [ModelBinder(Name = TokenConstants.Parameters.RefreshToken)]
        [JsonProperty(TokenConstants.Parameters.RefreshToken, NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; set; }


        [ModelBinder(Name = "tenant")]
        [JsonProperty("tenant", NullValueHandling = NullValueHandling.Ignore)]
        public Guid? TenantId { get; set; }
    }
}
