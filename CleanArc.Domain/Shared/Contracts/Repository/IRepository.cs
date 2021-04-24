using CleanArc.Domain.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArc.Domain.Shared.Contracts
{
    public interface IRepository<TEntity, TContext> where TEntity : BaseEntity 
                                                    where TContext : DbContext
    {
        ValueTask<bool> Add(TEntity entity);
        ValueTask<TEntity> GetById(Guid id);
        ValueTask<IQueryable<TEntity>> GetQuery();
        ValueTask<IEnumerable<TEntity>> GetAll();
        ValueTask<bool> Update(TEntity entity);
        ValueTask<bool> Remove(Guid id);
        ValueTask<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        ValueTask<bool> SaveChanges();
    }
}
