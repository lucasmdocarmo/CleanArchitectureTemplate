using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports.Models
{
    public interface ISucessPort<in TUseCaseOutput> where TUseCaseOutput : IUseCaseOutput, IBasePresenter
    {
        void Success(TUseCaseOutput output);
        void Success();
    }
}
