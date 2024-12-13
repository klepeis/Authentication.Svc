using System.Text.Json.Nodes;
using Authentication.Svc.Framework.Models;

namespace Authentication.Svc.Services;

public interface IGrantValidatorService
{
    TokenResponse ValidateGrant(JsonObject tokenRequest);
}