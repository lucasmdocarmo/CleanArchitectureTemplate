using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Shared.Contracts.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        void Rollback();
        void Begin();
        bool CheckIfDatabaseExists();
    }
}
