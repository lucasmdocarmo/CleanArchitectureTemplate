using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.DeleteClient.Boundaries
{
    public class DeleteClientOutput : IUseCaseOutput
    {
        public string Name { get; set; }
    }
}
