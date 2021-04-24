using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.CreateClient.Boundaries
{
    public class CreateClientInput : IUseCaseInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
