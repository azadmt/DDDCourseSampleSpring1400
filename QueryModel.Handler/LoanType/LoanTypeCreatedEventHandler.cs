using LoanManagement.Domain.Contract;
using MassTransit;
using QueryModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryModel.Handler.LoanType
{
    public class LoanTypeCreatedEventHandler : IConsumer<LoanTypeCreated>
    {
        private readonly QueryDbContext queryDbContext;

        public LoanTypeCreatedEventHandler(QueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }
        public Task Consume(ConsumeContext<LoanTypeCreated> context)
        {
            throw new NotImplementedException();
        }
    }
}
