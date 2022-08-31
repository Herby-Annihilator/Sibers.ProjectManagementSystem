using Sibers.ProjectManagementSystem.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Entities
{
    public class Employee : Entity
    {
        [Required]
        [MaxLength(256)]
        public string FirstName { get; set; } = "";

        [Required]
        [MaxLength(256)]
        public string LastName { get; set; } = "";

        [MaxLength(256)]
        public string Patronymic { get; set; } = "";

        [Required]
        [MaxLength(512)]
        public string Email { get; set; } = "";

        public ICollection<EmployeeInProject>? EmployeesInProject { get; set; } = new List<EmployeeInProject>();
    }
}
