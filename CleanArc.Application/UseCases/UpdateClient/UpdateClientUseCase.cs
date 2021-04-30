using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.UpdateClient.Boundaries;
using CleanArc.Application.UseCases.UpdateClient.Ports;
using CleanArc.Domain.Entities;
using CleanArc.Domain.Shared.Exceptions;
using CleanArch.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Application.UseCases.UpdateClient
{
    public class UpdateClientUseCase : IUseCase<UpdateClientInput>
    {
        private readonly IMapper _mapper;
        private readonly IUpdateClientPort _port;
        private readonly IClientRepository _repository;

        public UpdateClientUseCase(IMapper mapper, IUpdateClientPort port, IClientRepository repository)
        {
            _mapper = mapper;
            _port = port;
            _repository = repository;
        }

        public async ValueTask ExecuteTaskAsync(UpdateClientInput input)
        {
            try
            {
                var entity = await _repository.GetById(input.Id).ConfigureAwait(true);

                if(entity is null)
                {
                    _port.ValidationError("Client Not Found", nameof(input.Id));
                }

                var entityUpdated = entity.UpdateClient(_mapper.Map<Client>(input));
                if (!entityUpdated.IsValid)
                {
                    _port.ValidationErrors(entityUpdated.Notifications);
                    return;
                }
                await _repository.Update(entityUpdated).ConfigureAwait(true);

                _port.NoContent();
            }
            catch (CoreException ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
