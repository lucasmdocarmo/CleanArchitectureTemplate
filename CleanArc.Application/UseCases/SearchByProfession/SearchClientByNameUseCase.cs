using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.SearchByName.Boundaries;
using CleanArc.Application.UseCases.SearchByProfession.Ports;
using CleanArch.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Application.UseCases.SearchByProfession
{
    public class SearchClientByProfessionUseCase : IUseCase<SearchByProfessionInput>
    {
        private readonly IMapper _mapper;
        private readonly ISearchClientByProfessionPort _port;
        private readonly IClientRepository _repository;

        public SearchClientByProfessionUseCase(IMapper mapper, ISearchClientByProfessionPort port, IClientRepository repository)
        {
            _mapper = mapper;
            _port = port;
            _repository = repository;
        }

        public ValueTask ExecuteTaskAsync(SearchByProfessionInput input)
        {
            throw new NotImplementedException();
        }
    }
}
