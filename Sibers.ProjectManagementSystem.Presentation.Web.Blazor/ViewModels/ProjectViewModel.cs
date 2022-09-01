namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.ViewModels
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        public DateTime EndDate { get; set; } = DateTime.UtcNow;

        public int Priority { get; set; } = 0;

        public string NameOfCustomerCompany { get; set; } = "";

        public string NameOfContractorCompany { get; set; } = "";

        public ICollection<EmployeeViewModel> Employees { get; set; } = new List<EmployeeViewModel>();
        public EmployeeViewModel Manager { get; set; } = new EmployeeViewModel();        
    }
}
