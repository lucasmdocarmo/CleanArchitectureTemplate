using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArc.Application.UseCases.DeleteClient.Boundaries
{
    public class DeleteClientInput : IUseCaseInput
    {
        [Required(ErrorMessage ="Id Required")]
        public Guid Id { get; set; }
    }
}
