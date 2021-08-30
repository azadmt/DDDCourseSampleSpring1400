using CustomerManagement.ApplicationService.Contract.DataContract;
using CustomerManagement.Domain.Customer;
using Framework.Application;
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

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
        {
            UnitOfWork = unitOfWork;
            this.customerRepository = customerRepository;
        }

        public IUnitOfWork UnitOfWork { get; }

        public void Handle(CreateCustomerCommand command)
        {
            var c = new CustomerAggregate(Guid.NewGuid(),  command.Name, command.NationalCode);
            customerRepository.Add(c);
            UnitOfWork.Commit();
        }
    }
}
