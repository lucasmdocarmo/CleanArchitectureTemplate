using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports.Models
{
    public interface ICreatedPort<in TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput?, new ()
    {
        void Created(TUseCaseOutput output);
    }
}
