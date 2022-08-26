using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Abstractions
{
    public class NamedEntity : Entity
    {
        public string Name { get; set; } = "";
    }
}
