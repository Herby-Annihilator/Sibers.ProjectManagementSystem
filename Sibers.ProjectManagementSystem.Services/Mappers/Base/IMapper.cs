using Sibers.ProjectManagementSystem.Data.DTOs.Base;
using Sibers.ProjectManagementSystem.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.Mappers.Base
{
    public interface IMapper<TBaseEntity, TEntity>
    {
        TBaseEntity Map(TEntity entity);

        TEntity MapBack(TBaseEntity baseEntity);
    }
}
