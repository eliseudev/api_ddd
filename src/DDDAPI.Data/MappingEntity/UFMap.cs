using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.MappingEntity
{
    public class UFMap : IEntityTypeConfiguration<UFEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UFEntity> builder)
        {
            builder.ToTable("uf");

            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Sigla)
                .IsUnique();
        }
    }
}
