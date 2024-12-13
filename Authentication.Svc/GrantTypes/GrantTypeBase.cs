using Authentication.Svc.Services;

namespace Authentication.Svc.GrantTypes
{
    public class GrantTypeBase
    {
        protected static ITokenGenerationService TokenGenerationService = new TokenGenerationService(); // I think this can be static.
    }
}
