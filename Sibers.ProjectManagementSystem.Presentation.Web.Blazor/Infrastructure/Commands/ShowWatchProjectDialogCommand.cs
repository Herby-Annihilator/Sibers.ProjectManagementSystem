using MudBlazor;
using Sibers.ProjectManagementSystem.Data.Entities;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Dialogs;
using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Commands.Base;

namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Commands
{
    public class ShowWatchProjectDialogCommand : Command
    {
        protected IDialogService dialogService;
        public ShowWatchProjectDialogCommand(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        protected override bool CanExecute(object parameter) => (parameter is Project) && ((parameter as Project) != null);
        protected override void Execute(object parameter)
        {
            Project project = parameter as Project;
            var options = new DialogOptions
            {
                CloseButton = true,
                CloseOnEscapeKey = true,
                MaxWidth = MaxWidth.Large,
                FullWidth = true
            };
            DialogParameters parameters = new DialogParameters();
            parameters.Add("Project", project);
            var dialog = dialogService.Show<WatchProjectDialog>("Информация о проекте", parameters, options);
        }
    }
}
