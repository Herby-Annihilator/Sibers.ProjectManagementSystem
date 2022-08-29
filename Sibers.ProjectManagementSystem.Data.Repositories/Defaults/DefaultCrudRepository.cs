using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Repositories.Defaults
{
    public class DefaultCrudRepository<T> : ICrudRepository<T> where T : Entity
    {
        protected DbContext context;
        protected DbSet<T> entitySet;

        public DefaultCrudRepository(DbContext context)
        {
            this.context = context;
            entitySet = context.Set<T>();
        }
        protected bool autoSaveChanges = true;
        public virtual bool AutoSaveChanges { get => autoSaveChanges; set => autoSaveChanges = value; }

        public virtual T AddEntity(T entity)
        {
            if (entity != null)
            {
                entitySet.Add(entity);
                if (AutoSaveChanges)
                {
                    SaveChanges();
                }
            }
            return entity;
        }

        public virtual async Task<T> AddEntityAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                await entitySet.AddAsync(entity, cancellationToken).ConfigureAwait(false);
                if (AutoSaveChanges)
                {
                    await SaveChangesAsync(cancellationToken);
                }
            }
            return entity;
        }

        public virtual T DeleteEntity(int id)
        {
            T entity = GetById(id);
            return DeleteEntity(entity);
        }

        public virtual T DeleteEntity(T entity)
        {
            if (entity != null)
            {
                entitySet.Remove(entity);
                if (AutoSaveChanges)
                {
                    SaveChanges();
                }
            }
            return entity;
        }

        public virtual async Task<T> DeleteEntityAsync(int id, CancellationToken cancellationToken = default)
        {
            T entity = await GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
            return await DeleteEntityAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task<T> DeleteEntityAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                entitySet.Remove(entity);
                if (AutoSaveChanges)
                {
                    await SaveChangesAsync(cancellationToken);
                }
            }
            return entity;
        }

        public virtual IEnumerable<T> GetAlL() => entitySet.ToArray();

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await entitySet.ToArrayAsync(cancellationToken).ConfigureAwait(false);

        public virtual T GetById(int id) => entitySet.FirstOrDefault(e => e.Id == id);

        public virtual async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await entitySet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken).ConfigureAwait(false);

        public virtual bool SaveChanges() => context.SaveChanges() > 0 ? true : false;

        public virtual async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await context.SaveChangesAsync(cancellationToken) > 0 ? true : false;

        public virtual T UpdateEntity(T entity)
        {
            if (entity != null)
            {
                entitySet.Update(entity);
                if (AutoSaveChanges)
                {
                    SaveChanges();
                }
            }
            return entity;
        }

        public virtual async Task<T> UpdateEntityAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity != null)
            {
                entitySet.Update(entity);
                if (AutoSaveChanges)
                {
                    await SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }                
            }
            return entity;
        }
        protected bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
