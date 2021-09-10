using System;

namespace Framework.Application
{
    public class ExceptionLoggerCommandHanlerDecorator<TCommand> : ICommandHandler<TCommand>
where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        public ExceptionLoggerCommandHanlerDecorator(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(TCommand command)
        {
            try
            {
                commandHandler.Handle(command);
            }
            catch (Exception ex)
            {

                throw ;
            }
        }
    }
}
