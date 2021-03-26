using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.MappingEntity
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("municipio");

            builder.HasKey(mun => mun.Id);

            builder.HasIndex(mun => mun.CodIBGE)
                .IsUnique();

            //Aqui já identifica a ForeingKey
            builder.HasOne(mun => mun.UF)
                .WithMany(uf => uf.Municipios);
        }
    }
}
