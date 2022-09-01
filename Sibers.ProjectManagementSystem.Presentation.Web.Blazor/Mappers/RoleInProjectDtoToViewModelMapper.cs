using Sibers.ProjectManagementSystem.Data.DTOs;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.ViewModels;
using Sibers.ProjectManagementSystem.Services.Mappers.Base;

namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Mappers
{
    public class RoleInProjectDtoToViewModelMapper : IMapper<RoleInProjectDto, RoleInProjectViewModel>
    {
        public RoleInProjectDto Map(RoleInProjectViewModel entity)
        {
            return new RoleInProjectDto
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public RoleInProjectViewModel MapBack(RoleInProjectDto baseEntity)
        {
            return new RoleInProjectViewModel
            {
                Name = baseEntity.Name,
                Id = baseEntity.Id
            };
        }
    }
}
