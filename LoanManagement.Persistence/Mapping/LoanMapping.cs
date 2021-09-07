using Framework.Persistence.Ef;
using LoanManagement.Domain.LoanAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanManagement.Persistence.Mapping
{
    public class LoanMapping : EntityMapperBase<Loan>
    {
        public override void ConfigDataModel(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(p => p.OwnerId);
            builder.Property(p => p.LoanTypeId);
            builder.OwnsOne(p => p.LoanAmount);
            builder.Property(p => p.State);
            builder.Property(p => p.PayDate);
        }
    }
}
