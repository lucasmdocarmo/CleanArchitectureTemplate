using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Application.Contracts.Ports.Models
{
    public interface IPreconditionPort : IBasePresenter
    {
        void ValidationErrors(IEnumerable<Notification> notifications);
    }
}
