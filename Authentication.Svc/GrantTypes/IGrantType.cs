using System.Text.Json.Nodes;
using Authentication.Svc.Framework.Models;

namespace Authentication.Svc.GrantTypes;

internal interface IGrantType
{
    void Init(JsonObject tokenRequest);
    void ValidateUser();
    void BuildClaims();
    TokenResponse CreateResponse();
}