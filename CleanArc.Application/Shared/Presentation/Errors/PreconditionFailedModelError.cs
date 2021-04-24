﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Shared.Presentation.Errors
{
    [DefaultStatusCode(_statusCode)]
    public sealed class PreconditionFailedModelError : ObjectResult
    {
        private const int _statusCode = StatusCodes.Status412PreconditionFailed;

        public PreconditionFailedModelError(object value) : base(value)
        {
            StatusCode = _statusCode;
        }
    }
}
