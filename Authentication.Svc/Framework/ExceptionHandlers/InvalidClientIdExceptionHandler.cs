using Authentication.Svc.Framework.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Authentication.Svc.Framework.ExceptionHandlers
{
    public class InvalidClientIdExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is InvalidClientIdException invalidClientIdException)
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync(invalidClientIdException.Message, cancellationToken); //TODO: Check Error message and format

                return true;
            }

            return false;
        }
    }
}
