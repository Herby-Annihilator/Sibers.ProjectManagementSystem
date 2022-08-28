using Sibers.ProjectManagementSystem.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Repositories.Base
{
    public interface ICrudRepository<T> : IDisposable where T : Entity
    {
        bool AutoSaveChanges { get; set; }
        bool SaveChanges();
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> AddEntityAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> UpdateEntityAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> DeleteEntityAsync(int id, CancellationToken cancellationToken = default);
        Task<T> DeleteEntityAsync(T entity, CancellationToken cancellationToken = default);

        T GetById(int id);
        IEnumerable<T> GetAlL();
        T AddEntity(T entity);
        T UpdateEntity(T entity);
        T DeleteEntity(int id);
        T DeleteEntity(T entity);
    }
}
