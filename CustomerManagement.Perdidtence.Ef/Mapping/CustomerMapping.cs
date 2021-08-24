using CustomerManagement.Domain;
using CustomerManagement.Domain.Customer;
using Framework.Persistence.Ef;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Persistence.Ef.Mapping
{
    public class CustomerMapping : EntityMapperBase<CustomerAggregate>
    {

        public override void ConfigDataModel(EntityTypeBuilder<CustomerAggregate> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(25);
            builder.Property(p => p.NationalCode).HasMaxLength(10);
            builder.OwnsOne(p => p.HomeAddress);
            builder.OwnsOne(p => p.WorkAddress);
        }
    }
}
