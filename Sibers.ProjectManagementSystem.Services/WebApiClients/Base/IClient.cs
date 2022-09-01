using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.WebApiClients.Base
{
    public interface IClient<TDto>
    {
        Task<TDto> AddEntityAsync(TDto dto, CancellationToken cancellationToken = default);
        Task<TDto> UpdateEntityAsync(TDto dto, CancellationToken cancellationToken = default);
        Task<TDto> DeleteEntityAsync(TDto dto, CancellationToken cancellationToken = default);
        Task<TDto> GetEntityByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ICollection<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
