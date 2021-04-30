using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.DeleteClient.Boundaries;
using CleanArc.Application.UseCases.DeleteClient.Ports;
using CleanArch.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flunt.Notifications;
using CleanArc.Application.Shared.Messages;
using CleanArc.Domain.Shared.Exceptions;

namespace CleanArc.Application.UseCases.DeleteClient
{
    public class DeleteClientUseCase : IUseCase<DeleteClientInput>
    {
        private readonly IMapper _mapper;
        private readonly IDeleteClientPort _port;
        private readonly IClientRepository _repository;

        public DeleteClientUseCase(IMapper mapper, IDeleteClientPort port, IClientRepository repository)
        {
            _mapper = mapper;
            _port = port;
            _repository = repository;
        }

        public async ValueTask ExecuteTaskAsync(DeleteClientInput input)
        {
            if(string.IsNullOrWhiteSpace(input.Id.ToString()) || input.Id == null)
            {
                _port.ValidationError("Id Invalid", nameof(input.Id));
                return;
            }

            var entity = await _repository.GetById(input.Id).ConfigureAwait(true);
            if(entity == null)
            {
                _port.ValidationError("Client Not Found", nameof(input.Id));
                return;
            }
            try
            {
                var result = await _repository.Remove(entity.Id);
                if (!result)
                {
                    _port.UnprocessableEntity(ApplicationMessages.Deleted_Error);
                }

                _port.Success();
            }
            catch (CoreException ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
