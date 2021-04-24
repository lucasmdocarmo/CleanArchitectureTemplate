using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Shared.Presentation.Errors
{
    [Serializable]
    [DefaultStatusCode(_statusCode)]
    public class ServiceUnavailableError : ObjectResult
    {
        private const int _statusCode = StatusCodes.Status503ServiceUnavailable;

        public ServiceUnavailableError(object value) : base(value)
        {
            StatusCode = _statusCode;
        }
    }
}
