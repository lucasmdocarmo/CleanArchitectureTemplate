using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Contracts.Ports.Models;
using CleanArc.Application.UseCases.CreateClient.Boundaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.CreateClient.Ports
{
    public interface ICreateClientPort : ICreatedPort<CreateClienteOutput>, IPreconditionPort, IUnprocessableEntityPort, IBasePresenter
    {
    }
}
