using Framework.Application;
using System;

namespace CustomerManagement.ApplicationService.Contract.DataContract
{
    public class ApproveCustomerCommand : ICommand, ILoggableCommand,IRetryableCommand
    {
        public ApproveCustomerCommand()
        {
            RetryCount = 3;
            RetryDuration = 4;
        }
        public Guid Id { get; set; }
        public int RetryCount { get; set; }  
        public int RetryDuration { get; set; }
    }
}
