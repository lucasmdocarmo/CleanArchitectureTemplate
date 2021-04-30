using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.SearchByName.Boundaries;
using CleanArc.Application.UseCases.SearchByProfession.Ports;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArc.API.Controllers.V1.SearchByProfession
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUseCase<SearchByProfessionInput> _useCase;
        private readonly ISearchClientByProfessionPort _port;
        public ClientController(IUseCase<SearchByProfessionInput> useCase, ISearchClientByProfessionPort port)
        {
            _useCase = useCase;
            _port = port;
        }
        /// <summary>
        ///  Search Client
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Profession")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetAsync([FromQuery][Required] SearchByProfessionInput input)
        {
            if (!ModelState.IsValid)
            {
                var notifications = new List<Notification>();
                foreach (var erro in ModelState.Where(a => a.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors).ToList())
                {
                    notifications.Add(new Notification("invalidModel", erro.ErrorMessage));
                }
                _port.ValidationErrors(notifications);

                return _port.ViewModel();
            }

            await _useCase.ExecuteTaskAsync(input).ConfigureAwait(true);

            return _port.ViewModel();
        }
    }
}
