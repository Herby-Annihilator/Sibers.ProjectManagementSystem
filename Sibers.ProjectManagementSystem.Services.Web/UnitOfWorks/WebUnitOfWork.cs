using Sibers.ProjectManagementSystem.Data.DbContexts;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Base;
using Sibers.ProjectManagementSystem.Data.UnitsOfWork.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.Web.UnitOfWorks
{
    public class WebUnitOfWork : UnitOfWork<ProjectManagementSystemDbContext>, IUnitOfWork<ProjectManagementSystemDbContext>
    {
        public WebUnitOfWork(ProjectManagementSystemDbContext context) : base(context)
        {
        }
    }
}
