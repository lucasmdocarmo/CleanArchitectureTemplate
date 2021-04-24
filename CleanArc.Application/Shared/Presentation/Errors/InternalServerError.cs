using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArc.Application.Shared.Presentation.Errors
{
    [Serializable]
    [DefaultStatusCode(_statusCode)]
    public class InternalServerError : ObjectResult
    {
        public string Message { get; set; }
        private const int _statusCode = StatusCodes.Status500InternalServerError;

        public InternalServerError(object value) : base(value)
        {
            StatusCode = _statusCode;
            dynamic exception = value as Exception;
            if (exception is AggregateException)
            {
                var agEx = value as AggregateException;
                Message = string.Join(" | ", agEx.InnerExceptions.Select(e => e.Message));
            }
            else
            {
                Message = exception.Message;
            }
        }
    }
}
