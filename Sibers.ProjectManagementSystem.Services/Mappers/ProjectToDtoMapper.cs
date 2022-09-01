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
    public class ProjectToDtoMapper : IMapper<Project, ProjectDto>
    {
        private ICrudRepository<Employee> _employeeRepository;
        private ICrudRepository<RoleInProject> _roleInProjectRepository;
        private RoleInProject _employeeRole;
        private RoleInProject _managerRole;

        public ProjectToDtoMapper(ICrudRepository<Employee> employeeRepository, ICrudRepository<RoleInProject> roleInProjectRepository)
        {
            _employeeRepository = employeeRepository;
            _roleInProjectRepository = roleInProjectRepository;
            IEnumerable<RoleInProject> roles = _roleInProjectRepository.GetAlL();
            _employeeRole = roles.First(r => r.Name.ToLower() == "сотрудник");
            _managerRole = roles.First(r => r.Name.ToLower() == "руководитель");
        }

        public Project Map(ProjectDto baseEntity)
        {
            Project project = new Project();
            project.Id = baseEntity.Id;
            project.Name = baseEntity.Name;
            project.StartDate = baseEntity.StartDate;
            project.EndDate = baseEntity.EndDate;
            project.NameOfCustomerCompany = baseEntity.NameOfCustomerCompany;
            project.NameOfContractorCompany = baseEntity.NameOfContractorCompany;
            project.Priority = baseEntity.Priority;
            project.EmployeesInProject = new List<EmployeeInProject>();
            if (baseEntity.Employees != null)
            {
                foreach (var item in baseEntity.Employees)
                {
                    project.EmployeesInProject.Add(new EmployeeInProject
                    {
                        Project = project,
                        Employee = _employeeRepository.GetById(item.Id),
                        RoleInProject = _roleInProjectRepository
                            .GetById(item.ProjectRoleDtos.First(rp => rp.ProjectId == project.Id).RoleId)
                    });
                }
            }
            if (baseEntity.Manager != null)
            {
                project.EmployeesInProject.Add(new EmployeeInProject
                {
                    Employee = _employeeRepository.GetById(baseEntity.Manager.Id),
                    Project = project,
                    RoleInProject = _roleInProjectRepository
                        .GetById(baseEntity.Manager.ProjectRoleDtos.First(pr => pr.ProjectId == project.Id).RoleId)
                });
            }
            return project;
        }

        public ProjectDto MapBack(Project entity)
        {
            ProjectDto baseEntity = new ProjectDto();
            baseEntity.Id = entity.Id;
            baseEntity.Name = entity.Name;
            baseEntity.StartDate = entity.StartDate;
            baseEntity.EndDate = entity.EndDate;
            baseEntity.NameOfContractorCompany = entity.NameOfContractorCompany;
            baseEntity.NameOfCustomerCompany = entity.NameOfCustomerCompany;
            baseEntity.Priority = entity.Priority;
            baseEntity.Employees = new List<EmployeeDto>();
            Employee employee;
            if (entity.EmployeesInProject != null)
            {
                foreach (var item in entity.EmployeesInProject)
                {
                    employee = _employeeRepository.GetById(item.EmployeeId);
                    if (employee != default)
                    {
                        if (item.RoleInProjectId == _managerRole.Id)
                        {
                            baseEntity.Manager = new EmployeeDto
                            {
                                Id = employee.Id,
                                Email = employee.Email,
                                FirstName = employee.FirstName,
                                LastName = employee.LastName,
                                Patronymic = employee.Patronymic,
                                ProjectRoleDtos = new List<ProjectRoleDto>()
                            };
                        }
                        else
                        {
                            baseEntity.Employees.Add(new EmployeeDto
                            {
                                Id = employee.Id,
                                Email = employee.Email,
                                FirstName = employee.FirstName,
                                LastName = employee.LastName,
                                Patronymic = employee.Patronymic,
                                ProjectRoleDtos = new List<ProjectRoleDto>()
                            });
                        }                       
                    }                    
                }
            }
            return baseEntity;
        }
    }
}
