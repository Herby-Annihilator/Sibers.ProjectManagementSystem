using Sibers.ProjectManagementSystem.Data.DTOs;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Data.Repositories.Base;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.Mappers
{
    public class EmployeeToDtoMapper : IMapper<Employee, EmployeeDto>
    {
        private ICrudRepository<Project> _projectRepository;
        private ICrudRepository<RoleInProject> _roleInProjectRepository;

        public EmployeeToDtoMapper(ICrudRepository<Project> projectRepository, ICrudRepository<RoleInProject> roleInProjectRepository)
        {
            _projectRepository = projectRepository;
            _roleInProjectRepository = roleInProjectRepository;
        }

        public Employee Map(EmployeeDto baseEntity)
        {
            Employee employee = new Employee();
            employee.Id = baseEntity.Id;
            employee.FirstName = baseEntity.FirstName;
            employee.LastName = baseEntity.LastName;
            employee.Patronymic = baseEntity.Patronymic;
            employee.Email = baseEntity.Email;
            employee.EmployeesInProject = new List<EmployeeInProject>();
            if (baseEntity.ProjectRoleDtos != null)
            {
                foreach (var item in baseEntity.ProjectRoleDtos)
                {
                    employee.EmployeesInProject.Add(new EmployeeInProject
                    {
                        Employee = employee,
                        Project = _projectRepository.GetById(item.ProjectId),
                        RoleInProject = _roleInProjectRepository.GetById(item.RoleId)
                    });
                }
            }
            return employee;
        }

        public EmployeeDto MapBack(Employee entity)
        {
            EmployeeDto baseEntity = new EmployeeDto();
            baseEntity.Id = entity.Id;
            baseEntity.FirstName = entity.FirstName;
            baseEntity.LastName = entity.LastName;
            baseEntity.Patronymic = entity.Patronymic;
            baseEntity.Email = entity.Email;
            baseEntity.ProjectRoleDtos = new List<ProjectRoleDto>();
            if (entity.EmployeesInProject != null)
            {
                foreach (var item in entity.EmployeesInProject)
                {
                    baseEntity.ProjectRoleDtos.Add(new ProjectRoleDto
                    {
                        ProjectId = item.ProjectId,
                        ProjectName = _projectRepository.GetById(item.ProjectId).Name,
                        RoleId = item.RoleInProjectId,
                        RoleName = _roleInProjectRepository.GetById(item.RoleInProjectId).Name
                    });
                }
            }
            return baseEntity;
        }
    }
}
