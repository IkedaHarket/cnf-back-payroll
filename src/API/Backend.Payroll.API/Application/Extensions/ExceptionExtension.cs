using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Backend.PortalPrivado.API.Application.Extensions
{
    public static class ExceptionExtension
    {
        public static ErrorResponse ToError(this Exception ex, string message = null)
        {
            return new ErrorResponse
            {
                Error = message ?? ex.Message,
                Stack = ex.StackTrace,
                Inner = ex.InnerException?.StackTrace
            };
        }
    }
}
