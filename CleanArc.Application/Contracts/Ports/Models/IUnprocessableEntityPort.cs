using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports.Models
{
    public interface IUnprocessableEntityPort : IBasePresenter
    {
        void UnprocessableEntity(string errorMessage);
    }
}
