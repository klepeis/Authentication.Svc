using Authentication.Svc.Framework.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Svc.Framework.Extensions
{
    public static class HttpContextAccessorExtensions
    {
        public static TService GetService<TService>(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.RequestServices.GetService<TService>();
        }
    }
}
