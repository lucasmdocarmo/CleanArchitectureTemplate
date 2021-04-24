using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports
{
    public interface IBasePresenter
    {
        IActionResult ViewModelResult { get; set; }
        IActionResult ViewModel();
    }
}
