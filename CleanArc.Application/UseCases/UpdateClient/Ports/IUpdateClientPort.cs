using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Contracts.Ports.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.UpdateClient.Ports
{
    public interface IUpdateClientPort:INoContentPort, IPreconditionPort, IUnprocessableEntityPort, IBasePresenter
    {
    }
}
