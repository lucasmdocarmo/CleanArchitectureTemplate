using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Domain.Entities;
using CleanArc.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CleanArc.Application.UseCases.SearchByProfession.Boundaries
{
    public class SearchByProfessionOutput :IUseCaseOutput
    {
        public List<Client> Clients { get; set; }
        public SearchByProfessionOutput()
        {
            Clients = new List<Client>();
        }
    }
}
