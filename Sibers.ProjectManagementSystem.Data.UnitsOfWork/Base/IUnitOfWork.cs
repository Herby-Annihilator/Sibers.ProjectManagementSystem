using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base
{
    public interface IUnitOfWork : IDisposable
    {
        ICrudRepository<T> GetRequiredRepository<T>(bool hasCustomRepository = false) where T : Entity;
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork, IDisposable where TContext : DbContext
    {
        TContext DbContext { get; }
    }
}
