using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sibers.ProjectManagementSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.DbContexts;

namespace Sibers.ProjectManagementSystem.Data.Repositories
{
    public class EmployeeRepository : DefaultCrudRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ProjectManagementSystemDbContext context) : base(context)
        {
        }

        public override IEnumerable<Employee> GetAlL() =>
            entitySet.Include(r => r.EmployeesInProject)
            .ToArray();

        public override async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await entitySet.Include(r => r.EmployeesInProject)
            .ToArrayAsync()
            .ConfigureAwait(false);

        public override Employee GetById(int id) =>
            entitySet
            .Include(r => r.EmployeesInProject)
            .FirstOrDefault(r => r.Id == id);

        public override async Task<Employee> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await entitySet
            .Include(r => r.EmployeesInProject)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken)
            .ConfigureAwait(false);
    }
}
