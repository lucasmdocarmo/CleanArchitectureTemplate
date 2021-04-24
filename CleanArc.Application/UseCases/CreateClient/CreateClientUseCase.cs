using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.CreateClient.Boundaries;
using CleanArc.Application.UseCases.CreateClient.Ports;
using CleanArc.Domain.Entities;
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

        public CreateClientUseCase(IMapper mapper, ICreateClientPort port)
        {
            _mapper = mapper;
            _port = port;
        }

        public async ValueTask ExecuteTaskAsync(CreateClientInput input)
        {
            var entity = _mapper.Map<Client>(input);

            if (!entity.IsValid)
            {
                _port.ValidationErrors(entity.Notifications);
                return;
            }

            _port.NoContent();

            try
            {

            }
            catch (Exception ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
