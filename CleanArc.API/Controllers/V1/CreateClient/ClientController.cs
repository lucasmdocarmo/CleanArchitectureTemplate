using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.CreateClient.Boundaries;
using CleanArc.Application.UseCases.CreateClient.Ports;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArc.API.Controllers.V1.CreateClient
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUseCase<CreateClientInput> _useCase;
        private readonly ICreateClientPort _port;
        public ClientController(IUseCase<CreateClientInput> useCase, ICreateClientPort port)
        {
            _useCase = useCase;
            _port = port;
        }

        /// <summary>
        /// Create a New Client
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PostAsync([FromBody] CreateClientInput input)
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
