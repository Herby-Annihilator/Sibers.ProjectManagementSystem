using Microsoft.EntityFrameworkCore;
using Sibers.ProjectManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.DbContexts
{
    public class ProjectManagementSystemDbContext : DbContext
    {
        public ProjectManagementSystemDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<RoleInProject> RolesInProject { get; set; }
        public DbSet<EmployeeInProject> EmployeesInProject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInProject>()
                .HasKey(e => new { e.ProjectId, e.EmployeeId });

            modelBuilder.Entity<EmployeeInProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeesInProject)
                .HasForeignKey(ep => ep.ProjectId);

            modelBuilder.Entity<EmployeeInProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeesInProject)
                .HasForeignKey(ep => ep.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
