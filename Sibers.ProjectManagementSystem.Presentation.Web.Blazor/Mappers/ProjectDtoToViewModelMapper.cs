using Sibers.ProjectManagementSystem.Data.DTOs;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.ViewModels;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;

namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Mappers
{
    public class ProjectDtoToViewModelMapper : IMapper<ProjectDto, ProjectViewModel>
    {
        public ProjectDto Map(ProjectViewModel entity)
        {
            ProjectDto dto = new ProjectDto
            {
                Id = entity.Id,
                Name = entity.Name,
                NameOfContractorCompany = entity.NameOfContractorCompany,
                NameOfCustomerCompany = entity.NameOfCustomerCompany,
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Priority = entity.Priority,
                Employees = new List<EmployeeDto>()
            };
            if (entity.Employees != null)
            {
                foreach (var item in entity.Employees)
                {
                    dto.Employees.Add(new EmployeeDto
                    {
                        Id = item.Id,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Patronymic = item.Patronymic,
                        ProjectRoleDtos = GetDtos(item),
                    });
                }
            }
            if (entity.Manager != null)
            {
                dto.Manager = new EmployeeDto
                {
                    Id = entity.Manager.Id,
                    FirstName = entity.Manager.FirstName,
                    LastName = entity.Manager.LastName,
                    Patronymic = entity.Manager.Patronymic,
                    Email = entity.Manager.Email,
                    ProjectRoleDtos = GetDtos(entity.Manager)
                };
            }
            return dto;
        }

        private List<ProjectRoleDto> GetDtos(EmployeeViewModel model)
        {
            List<ProjectRoleDto> dtos = new List<ProjectRoleDto>();
            if (model != null && model.ProjectRoles != null)
            {
                foreach (var item in model.ProjectRoles)
                {
                    dtos.Add(new ProjectRoleDto
                    {
                        ProjectId = item.ProjectId,
                        ProjectName = item.ProjectName,
                        RoleId = item.RoleId,
                        RoleName = item.RoleName
                    });
                }
            }
            return dtos;
        }

        public ProjectViewModel MapBack(ProjectDto baseEntity)
        {
            ProjectViewModel model = new ProjectViewModel
            {
                Id = baseEntity.Id,
                Name = baseEntity.Name,
                NameOfContractorCompany = baseEntity.NameOfContractorCompany,
                NameOfCustomerCompany = baseEntity.NameOfCustomerCompany,
                Priority = baseEntity.Priority,
                StartDate = baseEntity.StartDate,
                EndDate = baseEntity.EndDate,
                Employees = new List<EmployeeViewModel>()
            };
            if (baseEntity.Employees != null)
            {
                foreach (var item in baseEntity.Employees)
                {
                    model.Employees.Add(new EmployeeViewModel
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Patronymic = item.Patronymic,
                        Email = item.Email,
                        ProjectRoles = GetProjectRoles(item)
                    });
                }
            }
            if (baseEntity.Manager != null)
            {
                model.Manager = new EmployeeViewModel
                {
                    Id = baseEntity.Manager.Id,
                    FirstName = baseEntity.Manager.FirstName,
                    LastName = baseEntity.Manager.LastName,
                    Patronymic = baseEntity.Manager.Patronymic,
                    Email = baseEntity.Manager.Email,
                    ProjectRoles = GetProjectRoles(baseEntity.Manager)
                };
            }
            return model;
        }

        private List<ProjectRole> GetProjectRoles(EmployeeDto dto)
        {
            List<ProjectRole> result = new List<ProjectRole>();
            if (dto != null && dto.ProjectRoleDtos != null)
            {
                foreach (var item in dto.ProjectRoleDtos)
                {
                    result.Add(new ProjectRole
                    {
                        ProjectId = item.ProjectId,
                        ProjectName = item.ProjectName,
                        RoleId = item.RoleId,
                        RoleName = item.RoleName,
                    });
                }
            }
            return result;
        }
    }
}
