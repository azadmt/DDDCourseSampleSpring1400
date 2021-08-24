using System.Diagnostics;

namespace Framework.Application
{
    public class CommandHanlerLoggerDecorator<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        public CommandHanlerLoggerDecorator(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(TCommand command)
        {
            Debug.WriteLine("start :"+command.ToString());
            commandHandler.Handle(command);
            Debug.WriteLine("end :"+command.ToString());

        }
    }
}
