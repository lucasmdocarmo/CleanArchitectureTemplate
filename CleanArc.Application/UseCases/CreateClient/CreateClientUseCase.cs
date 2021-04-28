using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.Shared.Messages;
using CleanArc.Application.UseCases.CreateClient.Boundaries;
using CleanArc.Application.UseCases.CreateClient.Ports;
using CleanArc.Domain.Entities;
using CleanArc.Domain.Shared.Exceptions;
using CleanArch.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Application.UseCases.CreateClient
{
    public class CreateClientUseCase : IUseCase<CreateClientInput>
    {
        private readonly IMapper _mapper;
        private readonly ICreateClientPort _port;
        private readonly IClientRepository _repository;

        public CreateClientUseCase(IMapper mapper, ICreateClientPort port, IClientRepository repository)
        {
            _mapper = mapper;
            _port = port;
            _repository = repository;
        }

        public async ValueTask ExecuteTaskAsync(CreateClientInput input)
        {
            var entity = _mapper.Map<Client>(input);

            if (!entity.IsValid)
            {
                _port.ValidationErrors(entity.Notifications);
                return;
            }
            try
            {
                var result =  await _repository.Add(entity);
                if(!result)
                {
                    _port.UnprocessableEntity(ApplicationMessages.Created_Error);
                }

                _port.Created(_mapper.Map<CreateClienteOutput>(entity));
            }
            catch (CoreException ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
