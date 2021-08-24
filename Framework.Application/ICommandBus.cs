using Framework.Application;
using System;
using System.Diagnostics;

namespace Framework.Application
{
    //public class CommandBus : ICommandBus
    //{
    //    public void Send<TCommand>(TCommand command) where TCommand : ICommand
    //    {
    //        //find command handler
    //        //handle()
    //    }
    //}
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }

    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand command);
    }

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
    public interface ICommand
    {

    }
}
public interface ILoggableCommand: ICommand
{

}

public interface IRetryableCommand: ICommand
{
    int RetryCount { get; set; }
    int RetryDuration { get; set; }
}
