using Sibers.ProjectManagementSystem.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Entities
{
    public class EmployeeInProject
    {
        public RoleInProject RoleInProject { get; set; }
        public int RoleInProjectId { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
