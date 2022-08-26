using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.Entities.Base
{
    public class NamedEntity : Entity
    {
        [Required]
        public virtual string Name { get; set; } = "";
    }
}
