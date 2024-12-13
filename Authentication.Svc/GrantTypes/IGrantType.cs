using System.Text.Json.Nodes;

namespace Authentication.Svc.GrantTypes;

internal interface IGrantType
{
    void Init(JsonObject tokenRequest);
    void ValidateUser();
    void BuildClaims();
    JsonObject CreateResponse();
}