using System;

namespace QueryModel.Data.DataModel
{
    public class LoanView
    {
        public Guid Id { get; private set; }
        public Guid OwnerId { get; private set; }
        public string Owner { get; private set; }

        public Guid LoanTypeId { get; private set; }
        public string LoanType { get; private set; }

        public decimal LoanAmount { get; private set; }

        public string State { get; private set; }
        public DateTime LoanPayDate { get; private set; }

    }
}
