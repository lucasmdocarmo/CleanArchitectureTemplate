using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports.Models
{
    public interface ICreatedPort<in TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput, IBasePresenter
    {
        void Created(TUseCaseOutput output);
        void Created(TUseCaseOutput output, string message);
    }
}
