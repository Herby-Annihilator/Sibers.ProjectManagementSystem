using Sibers.ProjectManagementSystem.Data.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.DTOs
{
    public class RoleInProjectDto : INamedDto
    {
        public string Name { get; set; } = "";
        public int Id { get; set; }
    }
}
