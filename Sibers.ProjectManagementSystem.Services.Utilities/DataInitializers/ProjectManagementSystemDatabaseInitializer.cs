using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Sibers.ProjectManagementSystem.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.Utilities.DataInitializers
{
    public static class ProjectManagementSystemDatabaseInitializer
    {
        public static void InitializeDatabase(IServiceProvider scopeServiceProvider)
        {
            var context = scopeServiceProvider.GetRequiredService<ProjectManagementSystemDbContext>();
            context.Database.Migrate();

            if (!context.Employees.Any())
            {

            }

            if (!context.Projects.Any())
            {

            }

            if (!context.RolesInProject.Any())
            {

            }

            if (!context.EmployeesInProject.Any())
            {

            }
        }
    }
}
