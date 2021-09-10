using CustomerManagement.Domain.Contract;
using MassTransit;
using QueryModel.Data;
using QueryModel.Data.DataModel;
using System;
using System.Threading.Tasks;

namespace QueryModel.Handler.Customer
{
    public class CustomerCreatedEventHandler : IConsumer<CustomerCreated>
    {
        private readonly QueryDbContext queryDbContext;

        public CustomerCreatedEventHandler(QueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }
        public async Task Consume(ConsumeContext<CustomerCreated> context)
        {
            var msg = context.Message;
            var customer = new CustomerView
            {
                Id = msg.Id,
                HomeAddress_City = msg.HomeAddress_City,
                HomeAddress_Street = msg.HomeAddress_Street,
                HomeAddress_Province = msg.HomeAddress_Province,
                WorkAddress_City = msg.WorkAddress_City,
                WorkAddress_Street = msg.WorkAddress_Street,
                WorkAddress_Province = msg.WorkAddress_Province,
                Name = msg.Name,
                NationalCode = msg.NationalCode
            }
            ;
            queryDbContext.CustomerViews.Add(customer);
            await queryDbContext.SaveChangesAsync();
        }
    }
}
