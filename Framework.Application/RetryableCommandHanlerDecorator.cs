using Polly;
using System;

namespace Framework.Application
{
    public class RetryableCommandHanlerDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        public RetryableCommandHanlerDecorator(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(TCommand command)
        {
            var retryableCommand = (command as IRetryableCommand);
            var policy = Policy
               .Handle<Exception>()
                .WaitAndRetry(retryableCommand.RetryCount, retryAttempt =>
                        TimeSpan.FromSeconds(retryableCommand.RetryDuration)
                               );
                policy.Execute(() => commandHandler.Handle(command));

        }
    }
}
