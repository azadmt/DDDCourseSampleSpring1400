using Framework.Core.Messageing;
using System;

namespace CustomerManagement.Domain.Contract
{
    public class CustomerCreated : IEvent, IIntegrationEvent
    {
        public CustomerCreated(
            Guid id,
            string name,
            string nationalCode,
            string homeAddress_Province,
            string homeAddress_City,
            string homeAddress_Street,
            string workAddress_Province,
            string workAddress_City,
            string workAddress_Street


            )
        {
            Id = id;
            Name = name;
            NationalCode = nationalCode;
            HomeAddress_Province = homeAddress_Province;
            HomeAddress_City = homeAddress_City;
            HomeAddress_Street = homeAddress_Street;
            WorkAddress_Province = workAddress_Province;
            WorkAddress_City = workAddress_City;
            WorkAddress_Street = workAddress_Street;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string NationalCode { get; }
        public string HomeAddress_Province { get; }
        public string HomeAddress_City { get; }
        public string HomeAddress_Street { get; }
        public string WorkAddress_Province { get; }
        public string WorkAddress_City { get; }
        public string WorkAddress_Street { get; }
    }
}
