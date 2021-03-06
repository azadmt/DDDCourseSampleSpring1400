using Framework.Domain;
using System.Collections.Generic;

namespace CustomerManagement.Domain.Customer
{
    public class Address : ValueObject
    {
        public Address()
        {

        }
        public Address(string province, string city, string street)
        {
            Province = province;
            City = city;
            Street = street;
        }
        public string Province { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new[] { Province, City, Street };
        }
    }
}
