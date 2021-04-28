using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Contracts.Ports.Models;
using CleanArc.Application.UseCases.SearchByProfession.Boundaries;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.SearchByProfession.Ports
{
    public interface ISearchClientByProfessionPort : ISucessPort<SearchByProfessionOutput>, IPreconditionPort, IUnprocessableEntityPort, IBasePresenter
    {
    }
}
