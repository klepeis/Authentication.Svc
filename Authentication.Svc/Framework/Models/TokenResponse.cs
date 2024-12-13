using System;
using System.Text.Json.Serialization;

namespace Authentication.Svc.Framework.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName(".expiration")]
        public DateTime Expiration { get; set; }
    }
}
