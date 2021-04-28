using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports.Models
{
    public interface INotFoundPort<in TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput
    {
        void NotFound();
        void NotFound(IUseCaseOutput output, object message);
    }
}
