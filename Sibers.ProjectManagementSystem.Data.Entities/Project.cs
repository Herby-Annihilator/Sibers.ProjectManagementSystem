using Sibers.ProjectManagementSystem.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Entities
{
    public class Project : NamedEntity
    {
        [Required]
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        
        [Required]
        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        [Required]
        public int Priority { get; set; } = 0;

        [Required]
        [MaxLength(512)]
        public string NameOfCustomerCompany { get; set; } = "";

        [Required]
        [MaxLength(512)]
        public string NameOfContractorCompany { get; set; } = "";

        public ICollection<EmployeeInProject>? EmployeesInProject { get; set; }
    }
}
