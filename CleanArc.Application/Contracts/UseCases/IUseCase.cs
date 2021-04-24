using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Application.Contracts.UseCases.Interactors
{
    public interface IUseCase<TUseCaseInput> where TUseCaseInput : IUseCaseInput
    {
        ValueTask ExecuteTaskAsync(TUseCaseInput input);
    }

}
