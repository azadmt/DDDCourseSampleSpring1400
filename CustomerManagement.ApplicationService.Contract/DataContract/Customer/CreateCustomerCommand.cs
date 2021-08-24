using Framework.Application;

namespace CustomerManagement.ApplicationService.Contract.DataContract
{
    public class CreateCustomerCommand :ICommand
    {
        public string NationalCode { get; set; }
    }
}
