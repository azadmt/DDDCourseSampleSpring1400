using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Persistence.Ef
{
    public abstract class EntityMapperBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.RowVersion).IsRowVersion();
            ConfigDataModel(builder);
        }

        public abstract void ConfigDataModel(EntityTypeBuilder<TEntity> builder);
    }
}
