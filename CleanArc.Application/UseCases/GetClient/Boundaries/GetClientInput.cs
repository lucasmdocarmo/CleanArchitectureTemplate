using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArc.Application.UseCases.GetClient.Boundaries
{
    public class GetClientInput : IUseCaseInput
    {
        [Required(ErrorMessage = "Id Required")]
        public Guid Id { get; set; }
    }
}
