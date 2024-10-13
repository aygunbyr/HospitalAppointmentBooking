namespace App.Services
{
    public abstract class CommandInvoker : ICommandInvoker
    {
        protected readonly Queue<ICommand> _commands = new Queue<ICommand>();
        public void AddCommand(ICommand command)
        {
            _commands.Enqueue(command);
        }

        public async Task ExecuteCommandsAsync()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();
                await command.ExecuteAsync();
            }
        }
    }
}
