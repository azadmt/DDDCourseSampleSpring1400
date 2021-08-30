using Autofac;
using Framework.Application;
using Polly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Framework.Configuration.Autofac
{
    public class AutofacCommandBus : ICommandBus
    {

        ILifetimeScope container;
        public AutofacCommandBus(ILifetimeScope container)
       {
            //// TODO : implement retry Command
            this.container = container;
        }



        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandhandler = container.Resolve<ICommandHandler<TCommand>>();

            if (command is ILoggableCommand)
                commandhandler = new CommandHanlerLoggerDecorator<TCommand>(commandhandler);

            if (command is IRetryableCommand)
                commandhandler = new RetryableCommandHanlerDecorator<TCommand>(commandhandler);

            commandhandler = new ExceptionLoggerCommandHanlerDecorator<TCommand>(commandhandler);
            commandhandler.Handle(command);
        }
        
    }
}
