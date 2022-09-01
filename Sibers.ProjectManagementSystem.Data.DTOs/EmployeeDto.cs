using Sibers.ProjectManagementSystem.Data.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.DTOs
{
    public class EmployeeDto : IDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string Email { get; set; } = "";
        public ICollection<ProjectRoleDto> ProjectRoleDtos { get; set; } = new List<ProjectRoleDto>();
    }

    public class ProjectRoleDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = "";

        public int RoleId { get; set; }
        public string RoleName { get; set; } = "";
    }
}
