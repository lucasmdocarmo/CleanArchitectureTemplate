﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports.Models
{
    public interface IUnprocessableEntityPort
    {
        void UnprocessableEntity(string errorMessage);
    }
}
