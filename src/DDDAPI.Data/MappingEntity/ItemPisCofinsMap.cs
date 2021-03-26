using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.MappingEntity
{
    public class ItemPisCofinsMap : IEntityTypeConfiguration<ItemPisCofinsEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemPisCofinsEntity> builder)
        {
            builder.ToTable("ItemPisCofins");

            builder.HasKey(i => i.Item_codigo);
        }
    }
}
