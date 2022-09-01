using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sibers.ProjectManagementSystem.API.Controllers.Base;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.DTOs;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;

namespace Sibers.ProjectManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleInProjectController : ProjectManagementSystemDefaultController<RoleInProject, RoleInProjectDto>
    {
        public RoleInProjectController(IUnitOfWork<ProjectManagementSystemDbContext> context,
                                       IMapper<RoleInProject, RoleInProjectDto> mapper) : base(context, mapper)
        {
            HasCustomRepository = true;
        }
    }
}
