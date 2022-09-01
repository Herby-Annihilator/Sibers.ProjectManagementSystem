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
    public class EmployeeController : ProjectManagementSystemDefaultController<Employee, EmployeeDto>
    {
        public EmployeeController(IUnitOfWork<ProjectManagementSystemDbContext> context,
                                  IMapper<Employee, EmployeeDto> mapper) : base(context, mapper)
        {
            HasCustomRepository = true;
        }
    }
}
