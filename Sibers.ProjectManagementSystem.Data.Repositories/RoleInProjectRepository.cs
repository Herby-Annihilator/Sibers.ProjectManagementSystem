using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Repositories
{
    public class RoleInProjectRepository : DefaultCrudRepository<RoleInProject>, IRoleInProjectRepository
    {
        public RoleInProjectRepository(ProjectManagementSystemDbContext context) : base(context)
        {
        }

        //public override IEnumerable<RoleInProject> GetAlL() =>
        //    entitySet.Include(r => r.EmployeesInProject)
        //    .ToArray();

        //public override async Task<IEnumerable<RoleInProject>> GetAllAsync(CancellationToken cancellationToken = default) =>
        //    await entitySet.Include(r => r.EmployeesInProject)
        //    .ToArrayAsync()
        //    .ConfigureAwait(false);

        //public override RoleInProject GetById(int id) =>
        //    entitySet
        //    .Include(r => r.EmployeesInProject)
        //    .FirstOrDefault(r => r.Id == id);

        //public override async Task<RoleInProject> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        //    await entitySet
        //    .Include(r => r.EmployeesInProject)
        //    .FirstOrDefaultAsync(r => r.Id == id, cancellationToken)
        //    .ConfigureAwait(false);
    }
}
