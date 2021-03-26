using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.MappingEntity
{
    public class CEPMap : IEntityTypeConfiguration<CEPEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CEPEntity> builder)
        {
            builder.ToTable("cep");

            builder.HasKey(cep => cep.Id);

            builder.HasIndex(cep => cep.CEP);

            //Aqui já identifica a ForeingKey
            builder.HasOne(cep => cep.Municipio)
                .WithMany(mun => mun.CEPs);
        }
    }
}
