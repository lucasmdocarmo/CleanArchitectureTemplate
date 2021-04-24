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
    public class TimeoutServerError : ObjectResult
    {
        private const int _statusCode = StatusCodes.Status408RequestTimeout;

        public TimeoutServerError(object value) : base(value)
        {
            StatusCode = _statusCode;
        }
    }
}
