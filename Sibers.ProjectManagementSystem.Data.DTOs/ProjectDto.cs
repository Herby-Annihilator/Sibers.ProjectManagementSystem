using Sibers.ProjectManagementSystem.Data.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.DTOs
{
    public class ProjectDto : INamedDto
    {
        public string Name { get; set; } = "";
        public int Id { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        public int Priority { get; set; } = 0;

        public string NameOfCustomerCompany { get; set; } = "";

        public string NameOfContractorCompany { get; set; } = "";

        public ICollection<EmployeeDto> Employees { get; set; } = new List<EmployeeDto>();
        public EmployeeDto Manager { get; set; } = new EmployeeDto();
    }
}
