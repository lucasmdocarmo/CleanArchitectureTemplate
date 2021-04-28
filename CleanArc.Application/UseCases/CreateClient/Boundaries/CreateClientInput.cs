﻿using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.CreateClient.Boundaries
{
    public class CreateClientInput : IUseCaseInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public EClientType Type { get; set; }
        public string Profession { get; set; }
    }
}
