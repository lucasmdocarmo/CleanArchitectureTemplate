using CleanArc.Application.Contracts.UseCases.Interactors;
using CleanArc.Application.UseCases.CreateClient.Ports;
using CleanArc.Application.UseCases.DeleteClient;
using CleanArc.Application.UseCases.DeleteClient.Boundaries;
using CleanArc.Application.UseCases.DeleteClient.Ports;
using Flunt.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArc.API.Controllers.V1.DeleteClient
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("V{api-version:apiVersion}/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IUseCase<DeleteClientInput> _useCase;
        private readonly IDeleteClientPort _port;
        public ClientController(IUseCase<DeleteClientInput> useCase, IDeleteClientPort port)
        {
            _useCase = useCase;
            _port = port;
        }

        /// <summary>
        /// Create a New Client
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}/Delete")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Notification), StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(typeof(string), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> PostAsync([FromRoute][Bind][Required] Guid id)
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
            var input = new DeleteClientInput() { Id = id };
            await _useCase.ExecuteTaskAsync(input).ConfigureAwait(true);

            return _port.ViewModel();
        }
    }
}
