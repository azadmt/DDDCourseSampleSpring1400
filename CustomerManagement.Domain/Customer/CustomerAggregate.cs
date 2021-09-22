using CustomerManagement.Domain.Contract;
using Framework.Domain;
using System;

namespace CustomerManagement.Domain.Customer
{
    public class CustomerAggregate : AggregateRoot
    {
        public string Name { get; private set; }
        public string NationalCode { get; private set; }
        public Address HomeAddress { get; private set; }
        public Address WorkAddress { get; private set; }

        private CustomerAggregate()
        {

        }

        public CustomerAggregate(Guid id, string name, string nationalCode, Address homeAddress, Address workAddress) : base(id)
        {
            NationalCode = nationalCode;
            Name = name;
            HomeAddress = homeAddress;
            WorkAddress = workAddress;
            AddChanges(new CustomerCreated(id, Name, NationalCode, homeAddress.Province, HomeAddress.City, HomeAddress.Street, WorkAddress.Province, WorkAddress.City, WorkAddress.Street));
        }

        public void Approve()
        {
            AddChanges(new CustomerApproved(Id));

        }
    }
}
