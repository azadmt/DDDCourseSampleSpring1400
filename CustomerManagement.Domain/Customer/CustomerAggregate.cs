using Framework.Domain;
using System;

namespace CustomerManagement.Domain.Customer
{
    public class CustomerAggregate : Entity
    {
        public string Name { get; private set; }
        public string NationalCode { get; private set; }
        public Address HomeAddress { get; private set; }
        public Address WorkAddress { get; private set; }

        public CustomerAggregate(Guid id,string name, string nationalCode) : base(id)
        {
            NationalCode = nationalCode;
            Name = name;
        }

        public void Approve()
        {
            //TODO
        }
    }
}
