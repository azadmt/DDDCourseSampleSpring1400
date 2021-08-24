using System;

namespace CustomerManagement.Domain.Customer
{
    public class CustomerAggregate
    {
        public Guid Id { get; private set; }
        public string NationalCode { get; private set; }

        public CustomerAggregate(Guid id, string nationalCode)
        {
            Id = id;
            NationalCode = nationalCode;
        }

        public void Approve()
        {
            //TODO
        }
    }
}
