namespace App.Services
{
    public interface ICommandInvoker
    {
        void AddCommand(ICommand command);
        Task ExecuteCommandsAsync();
    }
}
