using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.Repositories.Defaults;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.DbContexts;

namespace Sibers.ProjectManagementSystem.Data.Repositories
{
    public class ProjectRepository : DefaultCrudRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectManagementSystemDbContext context) : base(context)
        {
        }

        public override IEnumerable<Project> GetAlL() =>
            entitySet.Include(r => r.EmployeesInProject)
            .ToArray();

        public override async Task<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await entitySet.Include(r => r.EmployeesInProject)
            .ToArrayAsync()
            .ConfigureAwait(false);

        public override Project GetById(int id) =>
            entitySet
            .Include(r => r.EmployeesInProject)
            .FirstOrDefault(r => r.Id == id);

        public override async Task<Project> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
            await entitySet
            .Include(r => r.EmployeesInProject)
            .FirstOrDefaultAsync(r => r.Id == id, cancellationToken)
            .ConfigureAwait(false);
    }
}
