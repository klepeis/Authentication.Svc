using System.Text.Json.Nodes;
using Authentication.Svc.Framework.Exceptions;

namespace Authentication.Svc.Validators
{
    public class TokenRequestValidator
    {
        public static void Validate(JsonObject tokenRequest)
        {
            if(tokenRequest["grant_type"] == null)
            {
                throw new InvalidGrantTypeException();
            }
        }
    }
}
