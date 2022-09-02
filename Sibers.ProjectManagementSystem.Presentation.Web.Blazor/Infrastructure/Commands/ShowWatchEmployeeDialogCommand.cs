using MudBlazor;
using Sibers.ProjectManagementSystem.Data.DTOs;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Dialogs;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Commands.Base;

namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Commands
{
    public class ShowWatchEmployeeDialogCommand : Command
    {
        protected IDialogService dialogService;
        public ShowWatchEmployeeDialogCommand(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }
        protected override bool CanExecute(object parameter) => (parameter is EmployeeDto) && ((parameter as EmployeeDto) != null);
        protected override void Execute(object parameter)
        {
            EmployeeDto employee = parameter as EmployeeDto;
            DialogOptions options = new DialogOptions
            {
                CloseButton = true,
                CloseOnEscapeKey = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };
            DialogParameters parameters = new DialogParameters();
            parameters.Add("EmployeeToWatch", employee);
            var dialog = dialogService.Show<WatchEmployeeDialog>("Просмотр сотрудника", parameters, options);
        }
    }
}
