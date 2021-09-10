using Framework.Application;

namespace CustomerManagement.ApplicationService.Contract.DataContract
{
    public class CreateCustomerCommand : ICommand
    {
        public string Name { get; set; }
        public string NationalCode { get; set; }

        public string HomeAddress_Province { get; set; } = "Tehran";
        public string HomeAddress_City { get; set; } = "Tehran";
        public string HomeAddress_Street { get; set; } = "Azadi";

        public string WorkAddress_Province { get; set; } = "Gilan";
        public string WorkAddress_City { get; set; } = "Rasht";
        public string WorkAddress_Street { get; set; } = "moalem";
    }
}
