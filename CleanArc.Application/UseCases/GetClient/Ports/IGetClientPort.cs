using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Contracts.Ports.Models;
using CleanArc.Application.UseCases.GetClient.Boundaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.GetClient.Ports
{
    public interface IGetClientPort: ISucessPort<GetClientOutput>, IPreconditionPort, IUnprocessableEntityPort, IBasePresenter
    {
    }
}
