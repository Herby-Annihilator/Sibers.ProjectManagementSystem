using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.DTOs.Base
{
    public interface INamedDto : IDto
    {
        public string Name { get; set; }
    }
}
