using Sibers.ProjectManagementSystem.Data.DTOs;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.Mappers
{
    public class RoleInProjectToDtoMapper : IMapper<RoleInProject, RoleInProjectDto>
    {
        public RoleInProject Map(RoleInProjectDto baseEntity)
        {
            RoleInProject roleInProject = new RoleInProject();
            roleInProject.Name = baseEntity.Name;
            roleInProject.Id = baseEntity.Id;
            return roleInProject;
        }

        public RoleInProjectDto MapBack(RoleInProject entity)
        {
            RoleInProjectDto baseEntity = new RoleInProjectDto();
            baseEntity.Id = entity.Id;
            baseEntity.Name = entity.Name;
            return baseEntity;
        }
    }
}
