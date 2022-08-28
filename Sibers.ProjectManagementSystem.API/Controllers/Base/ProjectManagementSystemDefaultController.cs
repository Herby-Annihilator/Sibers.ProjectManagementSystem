using Microsoft.AspNetCore.Mvc;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;

namespace Sibers.ProjectManagementSystem.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementSystemDefaultController<TEntity> 
        : DefaultCrudController<ProjectManagementSystemDbContext, TEntity>
        where TEntity : Entity
    {
        public ProjectManagementSystemDefaultController(IUnitOfWork<ProjectManagementSystemDbContext> context)
            : base(context)
        {

        }
    }
}
