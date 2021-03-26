using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.MappingEntity
{
    public class ItemICMSMap : IEntityTypeConfiguration<ItemICMSEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemICMSEntity> builder)
        {
            builder.ToTable("ItemICMS");

            builder.HasKey(i => new {i.Item_codigo, i.UF});
        }
    }
}
