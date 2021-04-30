using CleanArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArc.Domain.Contracts.Entities
{
    public interface IClient
    {
        Client UpdateClient(Client client);
    }
}
