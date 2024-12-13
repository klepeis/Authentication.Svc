using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Nodes;

namespace Authentication.Svc.GrantTypes
{
    public class PasswordGrantType : GrantTypeBase, IGrantType
    {
        private List<Claim> _claims;
        private string _username;
        private string _password;

        /// <summary>
        /// Build claims for user
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void BuildClaims()
        {
        }

        public JsonObject CreateResponse()
        {
            TokenGenerationService.CreateAccessToken();
            TokenGenerationService.CreateRefreshToken();

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Digest tokenRequest and set local variables.
        /// </summary>
        /// <param name="tokenRequest"></param>
        public void Init(JsonObject tokenRequest)
        {
            _claims = new List<Claim>();
            _password = tokenRequest["password"]?.ToString();
            _username = tokenRequest["username"]?.ToString();
        }

        /// <summary>
        /// Perform grant specific validation.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void ValidateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
