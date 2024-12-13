using Authentication.Svc.GrantTypes;
using System.Text.Json.Nodes;

namespace Authentication.Svc.Services
{
    /// <summary>
    /// This object leverages the strategy pattern to select the appropriate grant type and validate the grant.
    /// </summary>
    internal class GrantValidatorService : IGrantValidatorService
    {
        public JsonObject ValidateGrant(JsonObject tokenRequest)
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
                    return new PasswordGrantType();
                case "refresh_token":
                    return new RefreshTokenGrantType();
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
