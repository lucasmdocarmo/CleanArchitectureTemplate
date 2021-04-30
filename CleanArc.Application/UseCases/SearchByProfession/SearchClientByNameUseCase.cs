using AutoMapper;
using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.SearchByName.Boundaries;
using CleanArc.Application.UseCases.SearchByProfession.Ports;
using CleanArch.Infrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Flunt.Notifications;
using CleanArc.Domain.Shared.Exceptions;
using CleanArc.Application.UseCases.SearchByProfession.Boundaries;
using CleanArc.Domain.Contracts.Entities;
using CleanArc.Domain.Entities;

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

        public async ValueTask ExecuteTaskAsync(SearchByProfessionInput input)
        {
            try
            {

                var entityquery = await _repository.GetAll().ConfigureAwait(true);

                var reusult = entityquery.Where(x => x.Profession.Contains(input.Profession));
                if (reusult == null)
                {
                    _port.ValidationError("Client Not Found", nameof(input.Profession));
                    return;
                }

                var output = new SearchByProfessionOutput();
                output.Clients.AddRange(reusult);
              
                _port.Success(output);
            }
            catch (CoreException ex)
            {
                _port.UnprocessableEntity(ex.Message);
            }
        }
    }
}
