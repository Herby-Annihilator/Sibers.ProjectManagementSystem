using Sibers.ProjectManagementSystem.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Entities
{
    public class RoleInProject : NamedEntity
    {
        public ICollection<EmployeeInProject>? EmployeesInProject { get; set; } = new List<EmployeeInProject>();
    }
}
