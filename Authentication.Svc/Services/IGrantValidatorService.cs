using System.Text.Json.Nodes;

namespace Authentication.Svc.Services;

public interface IGrantValidatorService
{
    JsonObject ValidateGrant(JsonObject tokenRequest);
}