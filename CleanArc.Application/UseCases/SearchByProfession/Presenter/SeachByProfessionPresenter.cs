using CleanArc.Application.Shared.Presentation;
using CleanArc.Application.UseCases.SearchByProfession.Boundaries;
using CleanArc.Application.UseCases.SearchByProfession.Ports;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.UseCases.SearchByProfession.Presenter
{
    public class SeachByProfessionPresenter : BasePresenter, ISearchClientByProfessionPort
    {
        public void Success(SearchByProfessionOutput output)
        {
            base.ViewModelResult = new OkObjectResult(output);
        }

        public void Success()
        {
            base.ViewModelResult = new OkResult();
        }
    }
}
