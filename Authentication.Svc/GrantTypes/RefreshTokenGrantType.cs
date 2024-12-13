using System.Text.Json.Nodes;

namespace Authentication.Svc.GrantTypes
{
    public class RefreshTokenGrantType : GrantTypeBase, IGrantType
    {
        public void BuildClaims()
        {
            throw new System.NotImplementedException();
        }

        public JsonObject CreateResponse()
        {
            throw new System.NotImplementedException();
        }

        public void Init(JsonObject tokenRequest)
        {
            throw new System.NotImplementedException();
        }

        public void ValidateUser()
        {
            throw new System.NotImplementedException();
        }
    }
}
