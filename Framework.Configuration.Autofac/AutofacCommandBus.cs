using Autofac;
using Framework.Application;
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
            // TODO : implement retry Command
            this.container = container;

            Timer t = new Timer(TimeSpan.FromSeconds(10).TotalSeconds); // Set the time (5 mins in this case)
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(CallRetryableCommands);
            t.Start();
        }

        private void CallRetryableCommands(object sender, ElapsedEventArgs e)
        {
            foreach (var item in retryableCommands
                .OfType<IRetryableCommand>()
                .Where(p => p.RetryCount > 0))
            {
                item.RetryCount = item.RetryCount - 1;
                Send(item);
            }
        }

        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandhandler = container.Resolve<ICommandHandler<TCommand>>();

            if (command is ILoggableCommand)
                commandhandler = new CommandHanlerLoggerDecorator<TCommand>(commandhandler);
            try
            {
                commandhandler.Handle(command);
            }
            catch (Exception )
            {
                if (command is IRetryableCommand)
                {
                    retryableCommands.Add(command );
                    return;
                }

                throw;
            }

        }
        

        IList<object>retryableCommands = new List<object>();
    }
}
