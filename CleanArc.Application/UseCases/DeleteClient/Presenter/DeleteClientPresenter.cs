using CleanArc.Application.Contracts.Ports;
using CleanArc.Application.Contracts.Ports.Models;
using CleanArc.Application.Shared.Presentation;
using CleanArc.Application.UseCases.DeleteClient.Boundaries;
using CleanArc.Application.UseCases.DeleteClient.Ports;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.DeleteClient.Presenter
{
    public class DeleteClientPresenter : BasePresenter, IDeleteClientPort
    {
        public void Success(DeleteClientOutput output)
        {
            base.ViewModelResult = new OkObjectResult(output);
        }

        public void Success()
        {
            base.ViewModelResult = new OkResult();
        }
    }
}
