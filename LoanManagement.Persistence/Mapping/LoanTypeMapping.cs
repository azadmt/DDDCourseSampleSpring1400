using Framework.Persistence.Ef;
using LoanManagement.Domain.LoanTypeAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanManagement.Persistence.Mapping
{
    public class LoanTypeMapping : EntityMapperBase<LoanType>
    {
        public override void ConfigDataModel(EntityTypeBuilder<LoanType> builder)
        {
            builder.Property(p => p.Code);
            builder.Property(p => p.PayDuration);
            builder.Property(p => p.Title);
        }
    }
}
