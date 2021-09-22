using CustomerManagement.ApplicationService.Contract.DataContract;
using CustomerManagement.Domain.Contract;
using CustomerManagement.Domain.Customer;
using Framework.Application;
using Framework.Core.Messageing;
using Framework.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.ApplicationService.Customer
{
    public class CreateCustomerCommandHandler :
        ICommandHandler<CreateCustomerCommand>
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEnterpriseServiceBus enterpriseServiceBus;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository, IEnterpriseServiceBus enterpriseServiceBus)
        {
            UnitOfWork = unitOfWork;
            this.customerRepository = customerRepository;
            this.enterpriseServiceBus = enterpriseServiceBus;
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Handle(CreateCustomerCommand command)
        {
            var home = new Address(command.HomeAddress_Province, command.HomeAddress_City, command.HomeAddress_Street);
            var work = new Address(command.WorkAddress_Province, command.WorkAddress_City, command.WorkAddress_Street);
            var customer = new CustomerAggregate(Guid.NewGuid(), command.Name, command.NationalCode, home, work);
            customerRepository.Add(customer);
            
            UnitOfWork.Commit();

            //var ce = new CustomerCreated(
            //   customer.Id,
            //   command.Name,
            //   command.NationalCode,
            //   command.HomeAddress_Province,
            //   command.HomeAddress_City,
            //   command.HomeAddress_Street,
            //   command.WorkAddress_Province,
            //   command.WorkAddress_City,
            //   command.WorkAddress_Street
            //    );
            //Task.Run(() => enterpriseServiceBus.PublishAsync(ce));
        }
    }
}
