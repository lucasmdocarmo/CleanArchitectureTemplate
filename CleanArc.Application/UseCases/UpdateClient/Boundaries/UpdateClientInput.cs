using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CleanArc.Application.UseCases.UpdateClient.Boundaries
{
    public class UpdateClientInput : IUseCaseInput
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [MaxLength(250)]
        public string Email { get; set; }
        [Display(Name = "Type", ResourceType = typeof(EClientType))]
        public EClientType Type { get; set; }
        [Required(ErrorMessage = "Profession Required")]
        [MaxLength(250)]
        public string Profession { get; set; }
    }
}
