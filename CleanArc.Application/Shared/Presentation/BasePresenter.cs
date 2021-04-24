using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Contracts.Ports.Models;
using CleanArc.Application.Shared.Presentation.Errors;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Shared.Presentation
{
    public class BasePresenter : IBasePresenter, IUnprocessableEntityPort, INoContentPort, IPreconditionPort
    {
        public IActionResult ViewModelResult { get; set; }

        public void NoContent()
        {
            ViewModelResult = new NoContentResult();
        }

        public void UnprocessableEntity(string errorMessage)
        {
            ViewModelResult = new UnprocessableEntityObjectResult(errorMessage);
        }

        public void ValidationErrors(IEnumerable<Notification> notifications)
        {
            ViewModelResult = new PreconditionFailedModelError(notifications);
        }

        public IActionResult ViewModel()
        {
            return this.ViewModelResult;
        }
    }
}
