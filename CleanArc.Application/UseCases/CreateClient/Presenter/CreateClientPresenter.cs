using CleanArc.Application.Shared.Presentation;
using CleanArc.Application.UseCases.CreateClient.Boundaries;
using CleanArc.Application.UseCases.CreateClient.Ports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.CreateClient.Presenter
{
    public class CreateClientPresenter : BasePresenter, ICreateClientPort
    {
        public void Created(CreateClienteOutput output)
        {
            base.ViewModelResult = new CreatedResult(string.Empty, output);
        }
    }
}
