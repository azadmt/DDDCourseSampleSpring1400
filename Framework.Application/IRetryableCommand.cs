using Framework.Application;

public interface IRetryableCommand: ICommand
{
    int RetryCount { get; set; }
    int RetryDuration { get; set; }
}
