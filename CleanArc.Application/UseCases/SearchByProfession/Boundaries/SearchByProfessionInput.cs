using CleanArc.Application.Contracts.UseCases.Interactors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArc.Application.UseCases.SearchByName.Boundaries
{
    public class SearchByProfessionInput : IUseCaseInput
    {
        [Required(ErrorMessage = "Profession Required")]
        [MaxLength(250)]
        public string Profession { get; set; }
    }
}
