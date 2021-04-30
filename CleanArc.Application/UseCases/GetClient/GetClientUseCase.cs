using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.Shared.Messages;
using CleanArc.Application.UseCases.GetClient.Boundaries;
using CleanArc.Application.UseCases.GetClient.Ports;
using CleanArc.Domain.Shared.Exceptions;
using CleanArch.Infrastructure.Contracts;
using Flunt.Notifications;
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

        public async ValueTask ExecuteTaskAsync(GetClientInput input)
        {
            if (string.IsNullOrWhiteSpace(input.Id.ToString()) || input.Id == null)
            {
                _port.ValidationError("Id Invalid", nameof(input.Id));
                return;
            }

            try
            {
                var entity = await _repository.GetById(input.Id).ConfigureAwait(true);
                if (entity == null)
                {
                    _port.ValidationError("Client Not Found", nameof(input.Id));
                    return;
                }

                _port.Success(_mapper.Map<GetClientOutput>(entity));
            }
            catch (CoreException ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
