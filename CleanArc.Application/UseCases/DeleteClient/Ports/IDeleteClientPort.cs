using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Contracts.Ports.Models;
using CleanArc.Application.UseCases.DeleteClient.Boundaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.DeleteClient.Ports
{
    public interface IDeleteClientPort : ISucessPort<DeleteClientOutput>, IPreconditionPort, IUnprocessableEntityPort, IBasePresenter
    {
    }
}
