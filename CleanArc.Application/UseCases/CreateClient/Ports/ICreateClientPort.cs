using CleanArc.Application.Contracts.Ports.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.CreateClient.Ports
{
    public interface ICreateClientPort : IPreconditionPort, IUnprocessableEntityPort, INoContentPort
    {
    }
}
