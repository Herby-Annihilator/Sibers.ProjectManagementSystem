using Microsoft.AspNetCore.Mvc;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;

namespace Sibers.ProjectManagementSystem.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagementSystemDefaultController<TEntity, TDto> 
        : DefaultCrudController<ProjectManagementSystemDbContext, TEntity, TDto>
        where TEntity : Entity
        where TDto : class
    {
        public ProjectManagementSystemDefaultController(IUnitOfWork<ProjectManagementSystemDbContext> context, IMapper<TEntity, TDto> mapper)
            : base(context, mapper)
        {

        }
    }
}
