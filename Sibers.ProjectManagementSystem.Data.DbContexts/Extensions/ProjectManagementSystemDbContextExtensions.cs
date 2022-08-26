using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sibers.ProjectManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Data.DbContexts.Extensions
{
    public static class ProjectManagementSystemDbContextExtensions
    {
        public static void EnsureSeedData(this ProjectManagementSystemDbContext context, bool seedData)
        {
            context.Database.Migrate();
            if (seedData)
            {
                context.ClearDatabase();
                context.FillDatabase();
            }
        }

        private static void ClearDatabase(this ProjectManagementSystemDbContext context)
        {
            if (context.Projects.Any())
            {
                context.Projects.RemoveRange(context.Projects);
                context.SaveChanges();
            }
            if (context.Employees.Any())
            {
                context.Employees.RemoveRange(context.Employees);
                context.SaveChanges();
            }
            if (context.EmployeesInProject.Any())
            {
                context.EmployeesInProject.RemoveRange(context.EmployeesInProject);
                context.SaveChanges();
            }
            if (context.RolesInProject.Any())
            {
                context.RolesInProject.RemoveRange(context.RolesInProject);
                context.SaveChanges();
            }
        }

        private static void FillDatabase(this ProjectManagementSystemDbContext context)
        {
            Project[] projects = new Project[]
                {
                    new Project
                        {
                            Id = 1,
                            Name = "Test",
                            NameOfCustomerCompany = "Sibers",
                            NameOfContractorCompany = "RukinStudio",
                            Priority = 10,
                            StartDate = new DateTime(2022, 8, 22),
                            EndDate = new DateTime(2022, 8, 29)
                        },
                        new Project
                        {
                            Id = 2,
                            Name = "FirstProject",
                            NameOfCustomerCompany = "Some customer company",
                            NameOfContractorCompany = "Microsoft",
                            Priority = 5,
                            StartDate = new DateTime(2021, 8, 22),
                            EndDate = new DateTime(2022, 8, 29)
                        },
                        new Project
                        {
                            Id = 3,
                            Name = "Second",
                            NameOfCustomerCompany = "Microsoft",
                            NameOfContractorCompany = "Sibers",
                            Priority = 7,
                            StartDate = new DateTime(2022, 1, 22),
                            EndDate = new DateTime(2022, 12, 29)
                        }
                };
            context.Projects.AddRange(projects);
            context.SaveChanges();

            int employeesCount = 33;
            int id;
            Employee[] employees = new Employee[employeesCount];
            for (int i = 0; i < employeesCount; i++)
            {
                id = i + 1;
                employees[i] = new Employee
                {
                    Id = id,
                    FirstName = $"EmployeeFirstName_{id}",
                    LastName = $"EmployeeLastName_{id}",
                    Patronymic = $"EmployeePatronymic_{id}",
                    Email = $"employee_{id}_@gmail.com"
                };
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            RoleInProject[] rolesInProject = new RoleInProject[]
            {
                    new RoleInProject
                        {
                            Id = 1,
                            Name = "Руководитель"
                        },
                        new RoleInProject
                        {
                            Id = 1,
                            Name = "Сотрудник"
                        }
            };
            context.RolesInProject.AddRange(rolesInProject);
            context.SaveChanges();


            for (int i = 0; i < 3; i++)
            {
                for (int j = i * 10 + i; j < (i + 1) * 10 + i; j++)
                {
                    context.EmployeesInProject.Add(new EmployeeInProject
                    {
                        EmployeeId = j + 1,
                        ProjectId = i + 1,
                        RoleInProjectId = j == i * 10 + i ? 1 : 2
                    });
                }
            }
            context.SaveChanges();
        }
    }
}
