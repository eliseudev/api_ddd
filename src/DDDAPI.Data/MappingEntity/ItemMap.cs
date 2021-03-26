using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.MappingEntity
{
    public class ItemMap : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItemEntity> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(i => i.Codigo);

            builder.HasIndex(i => i.CodigoBarras)
                .IsUnique();

            builder.HasIndex(i => i.DataCadastro);

            builder.HasIndex(i => i.DataEdicao);

            builder.HasIndex(i => i.NCM);

            builder.HasIndex(i => i.Descricao);

            builder.HasOne(a => a.PisCofins)
                .WithOne(b => b.Item)
                .HasForeignKey<ItemPisCofinsEntity>(b => b.Item_codigo);
        }
    }
}
