using Framework.Domain;
using System;
using System.Collections.Generic;

namespace LoanManagement.Domain.LoanAggregate
{
    public class Money : ValueObject
    {
        public string Currency { get; private set; }
        public decimal Value { get; private set; }
        public Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        private Money() { }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new object[] { Value, Currency };
        }

        public static Money operator +(Money left, Money right)
        {
            return new Money(left.Value + right.Value, left.Currency);
        }

    
    }
}

