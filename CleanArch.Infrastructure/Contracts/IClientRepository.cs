using CleanArc.Domain.Entities;
using CleanArc.Domain.Shared.Contracts;
using CleanArch.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infrastructure.Contracts
{
    public interface IClientRepository : IRepository<Client, APIContext>
    {
    }
}
