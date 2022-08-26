using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sibers.ProjectManagementSystem.API.Controllers.Base;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;

namespace Sibers.ProjectManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleInProjectController : ProjectManagementSystemDefaultController<RoleInProject>
    {
        public RoleInProjectController(IUnitOfWork<ProjectManagementSystemDbContext> context) : base(context)
        {
        }
    }
}
