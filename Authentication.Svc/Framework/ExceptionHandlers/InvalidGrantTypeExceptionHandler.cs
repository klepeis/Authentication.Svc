using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Authentication.Svc.Framework.Exceptions;

namespace Authentication.Svc.Framework.ExceptionHandlers
{
    public class InvalidGrantTypeExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is InvalidGrantTypeException invalidGrantTypeException)
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync(invalidGrantTypeException.Message, cancellationToken);

                return true;
            }

            return false;
        }
    }
}
