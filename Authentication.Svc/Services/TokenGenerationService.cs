using System;

namespace Authentication.Svc.Services
{
    public class TokenGenerationService : ITokenGenerationService
    {
        public string CreateAccessToken()
        {
            return Guid.NewGuid().ToString();
        }

        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
