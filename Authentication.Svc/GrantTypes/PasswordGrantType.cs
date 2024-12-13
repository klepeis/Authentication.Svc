using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json.Nodes;
using Authentication.Svc.Framework.Models;

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
            _claims.Add(new Claim("username", _username));
            _claims.Add(new Claim("system", "something"));
        }

        public TokenResponse CreateResponse()
        {
            return new TokenResponse()
            {
                AccessToken = TokenGenerationService.CreateAccessToken(),
                RefreshToken = TokenGenerationService.CreateRefreshToken(),
                Expiration = DateTime.Now.AddMinutes(30)
            };

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
            if (_password.Equals("p@ssw0rD")) // User Validated
            {
                return;
            }

            // Not Validated throw some sort of exception
            throw new System.NotImplementedException();
        }
    }
}
