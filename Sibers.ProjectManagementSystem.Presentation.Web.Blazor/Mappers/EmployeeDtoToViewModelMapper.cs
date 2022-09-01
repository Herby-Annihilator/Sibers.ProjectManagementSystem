using Sibers.ProjectManagementSystem.Data.DTOs;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.ViewModels;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;

namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Mappers
{
    public class EmployeeDtoToViewModelMapper : IMapper<EmployeeDto, EmployeeViewModel>
    {
        public EmployeeDto Map(EmployeeViewModel entity)
        {
            EmployeeDto dto = new EmployeeDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Patronymic = entity.Patronymic,
                Email = entity.Email,
                ProjectRoleDtos = new List<ProjectRoleDto>()
            };
            if (entity.ProjectRoles != null)
            {
                foreach (var item in entity.ProjectRoles)
                {
                    dto.ProjectRoleDtos.Add(new ProjectRoleDto
                    {
                        ProjectId = item.ProjectId,
                        ProjectName = item.ProjectName,
                        RoleId = item.RoleId,
                        RoleName = item.RoleName,
                    });
                }
            }
            return dto;
        }

        public EmployeeViewModel MapBack(EmployeeDto baseEntity)
        {
            EmployeeViewModel model = new EmployeeViewModel
            {
                Id = baseEntity.Id,
                FirstName = baseEntity.FirstName,
                LastName = baseEntity.LastName,
                Patronymic = baseEntity.Patronymic,
                Email = baseEntity.Email,
                ProjectRoles = new List<ProjectRole>()
            };
            if (baseEntity.ProjectRoleDtos != null)
            {
                foreach (var item in baseEntity.ProjectRoleDtos)
                {
                    model.ProjectRoles.Add(new ProjectRole
                    {
                        ProjectId = item.ProjectId,
                        ProjectName = item.ProjectName,
                        RoleId= item.RoleId,
                        RoleName = item.RoleName
                    });
                }
            }
            return model;
        }
    }
}
