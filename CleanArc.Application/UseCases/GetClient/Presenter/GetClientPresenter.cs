using CleanArc.Application.Shared.Presentation;
using CleanArc.Application.UseCases.GetClient.Boundaries;
using CleanArc.Application.UseCases.GetClient.Ports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.GetClient.Presenter
{
    public class GetClientPresenter : BasePresenter, IGetClientPort
    {
        public void Success(GetClientOutput output)
        {
            base.ViewModelResult = new OkObjectResult(output);
        }

        public void Success()
        {
            base.ViewModelResult = new OkResult();
        }
    }
}
