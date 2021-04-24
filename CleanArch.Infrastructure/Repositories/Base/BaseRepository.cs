using CleanArc.Domain.Shared.Contracts;
using CleanArc.Domain.Shared.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using CleanArc.Domain.Shared.Exceptions;

namespace CleanArch.Infrastructure.Repositories.Base
{
    public class BaseRepository<TEntity, TContext> : IRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : DbContext
    {
        protected readonly TContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository() { }
        protected BaseRepository(TContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async ValueTask<bool> Add(TEntity entity)
        {
            DbSet.Add(entity);
            return await SaveChanges();
        }

        public async ValueTask<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async ValueTask<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async ValueTask<IQueryable<TEntity>> GetQuery()
        {
            return DbSet.AsQueryable<TEntity>();
        }

        public async ValueTask<bool> Remove(Guid id)
        {
            var entity = await DbSet.FindAsync(id).ConfigureAwait(true);
            if (entity != null)
            {
                DbSet.Remove(entity);
            }
            return await SaveChanges();
        }

        public async ValueTask<bool> SaveChanges()
        {
            try
            {
                Db.ChangeTracker.DetectChanges();

                foreach (var entry in Db.ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("LastUpdated") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("LastUpdated").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("LastUpdated").CurrentValue = DateTime.Now;
                    }
                }
                return await Db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new CoreException(ex.Message);
            }

        }

        public async ValueTask<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async ValueTask<bool> Update(TEntity entity)
        {
            DbSet.Update(entity);
            return await SaveChanges();
        }
    }
}
