using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.UpdateClient.Boundaries;
using CleanArc.Application.UseCases.UpdateClient.Ports;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArc.API.Controllers.V1.UpdateClient
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUseCase<UpdateClientInput> _useCase;
        private readonly IUpdateClientPort _port;
        public ClientController(IUseCase<UpdateClientInput> useCase, IUpdateClientPort port)
        {
            _useCase = useCase;
            _port = port;
        }
        /// <summary>
        ///  Update Client
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetAsync([FromRoute][Bind][Required] Guid id, UpdateClientInput input)
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
            input.Id = id;
            await _useCase.ExecuteTaskAsync(input).ConfigureAwait(true);

            return _port.ViewModel();
        }
    }
}
