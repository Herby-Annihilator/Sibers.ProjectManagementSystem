namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Commands.Base
{
    public interface ICommand
    {
        void Execute(object? parameter);
        bool CanExecute(object? parameter);
    }
}
