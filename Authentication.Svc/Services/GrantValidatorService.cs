using Authentication.Svc.Extensions;
using Authentication.Svc.GrantTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Nodes;
using Authentication.Svc.Framework.Models;

namespace Authentication.Svc.Services
{
    /// <summary>
    /// This object leverages the strategy pattern to select the appropriate grant type and validate the grant.
    /// </summary>
    internal class GrantValidatorService : IGrantValidatorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GrantValidatorService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public TokenResponse ValidateGrant(JsonObject tokenRequest)
        {
            IGrantType grantType = SelectGrantType(tokenRequest["grant_type"]?.ToString());
            grantType.Init(tokenRequest);
            grantType.ValidateUser();
            grantType.BuildClaims();
            return grantType.CreateResponse();
        }

        private IGrantType SelectGrantType(string grantType)
        {
            switch (grantType)
            {
                case "password":
                    return _httpContextAccessor.GetService<PasswordGrantType>();
                case "refresh_token":
                    return _httpContextAccessor.GetService<RefreshTokenGrantType>();
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
