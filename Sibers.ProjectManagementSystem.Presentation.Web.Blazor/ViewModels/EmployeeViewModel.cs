namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string Email { get; set; } = "";
        public ICollection<ProjectRole> ProjectRoles { get; set; } = new List<ProjectRole>();
    }

    public class ProjectRole
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = "";

        public int RoleId { get; set; }
        public string RoleName { get; set; } = "";
    }
}
