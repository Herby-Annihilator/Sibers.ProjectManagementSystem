using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.UnitsOfWork.Defaults
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        protected Dictionary<Type, object> repositories;
        protected TContext context;
        public TContext DbContext => context ?? throw new ArgumentNullException(nameof(context));

        public UnitOfWork(TContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        protected bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public ICrudRepository<T> GetRequiredRepository<T>(bool hasCustomRepository = false) where T : Entity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }
            Type type = typeof(T);

            if (hasCustomRepository)
            {
                ICrudRepository<T> repository = DbContext.GetService<ICrudRepository<T>>();
                if (repository != null)
                {
                    return repository;
                }     
            }

            if (!repositories.ContainsKey(type))
            {
                repositories.Add(type, new DefaultCrudRepository<T>(DbContext));
            }
            return (ICrudRepository<T>)repositories[type];
        }
    }
}
