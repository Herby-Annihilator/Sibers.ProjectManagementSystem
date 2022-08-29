using Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Commands.Base;

namespace Sibers.ProjectManagementSystem.Presentation.Web.Blazor.Infrastructure.Commands
{
    public class LambdaCommand : Command
    {
        protected Action<object> execute;
        protected Func<object, bool> canExecute;
        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        protected override bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;

        protected override void Execute(object parameter) => execute?.Invoke(parameter);
    }
}
