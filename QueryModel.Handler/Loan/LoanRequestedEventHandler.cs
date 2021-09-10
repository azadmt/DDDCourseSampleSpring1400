using LoanManagement.Domain.Contract;
using MassTransit;
using QueryModel.Data;
using System;
using System.Threading.Tasks;

namespace QueryModel.Handler.Loan
{
    public class LoanRequestedEventHandler : IConsumer<LoanRequested>
    {
        private readonly QueryDbContext queryDbContext;

        public LoanRequestedEventHandler(QueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }
        public Task Consume(ConsumeContext<LoanRequested> context)
        {
            throw new NotImplementedException();
        }
    }
}
