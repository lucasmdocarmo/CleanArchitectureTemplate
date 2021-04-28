using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.GetClient.Boundaries;
using CleanArc.Application.UseCases.GetClient.Ports;
using CleanArch.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Application.UseCases.GetClient
{
    public class GetClientUseCase : IUseCase<GetClientInput>
    {
        private readonly IMapper _mapper;
        private readonly IGetClientPort _port;
        private readonly IClientRepository _repository;

        public GetClientUseCase(IMapper mapper, IGetClientPort port, IClientRepository repository)
        {
            _mapper = mapper;
            _port = port;
            _repository = repository;
        }

        public ValueTask ExecuteTaskAsync(GetClientInput input)
        {
            throw new NotImplementedException();
        }
    }
}
