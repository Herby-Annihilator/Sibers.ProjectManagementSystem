using Sibers.ProjectManagementSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibers.ProjectManagementSystem.Services.Utilities.DataInitializers.InitialData
{
    public static class MinimalData
    {

        public static List<Employee> Employees => GetEmployees(5);

        private static List<Employee> GetEmployees(int count)
        {
            var employees = new List<Employee>();
            for (int i = 0; i < count; i++)
            {
                employees.Add(new Employee()
                {
                    Id = i,
                    FirstName = $"EmloyeeFirstName_{i}",
                    LastName = $"EmployeeLastName_{i}",
                    Patronymic = $"EmployeePatronymic_{i}",
                    Email = $"Employee_{i}_mail.ru",
                });
            }
            return employees;
        }

        public static List<RoleInProject> RolesInProject => new List<RoleInProject>()
        { 
            new RoleInProject() { Id = 0, Name = "Управляющий" },
            new RoleInProject() { Id = 1, Name = "Сотрудник" },
        };

        public static List<Project> Projects => new List<Project>()
        {
            new Project() { Id = 0, Name = "Простой проект",  }
        };
    }
}
