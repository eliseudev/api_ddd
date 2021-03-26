using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDDAPI.Data.MappingEntity
{
    public class UsuarioAPIMap : IEntityTypeConfiguration<UsuarioAPIEntity>
    {
        public void Configure(EntityTypeBuilder<UsuarioAPIEntity> builder)
        {
            builder.ToTable("usuarioapi");

            builder.HasKey(u => u.CNPJ);

            builder.Property(u => u.CNPJ)
                .IsRequired()
                .HasMaxLength(14)
                .IsFixedLength(true)
                .HasComment("CNPJ da empresa contratante do serviço");
            
            builder.Property(u => u.Token)
                .HasComment("Armazena o token de acesso do usuário em questão");

            builder.Property(u => u.UF)
                .IsRequired()
                .HasMaxLength(2)
                .IsFixedLength(true)
                .HasComment("informa UF que o token recebe as informações");
            
            builder.Property(u => u.Dados)
                .HasComment("Informa se a api retornará os dados adicionais do item nas consultas");

            builder.Property(u => u.Imagens)
                .HasComment("informa se a api irá retornar as imagens do item nas consultas");
            
            builder.Property(u => u.Senha)
                .HasMaxLength(32)
                .IsFixedLength(true)
                .HasComment("Comentário da tabela")
                .HasComment("Informa a senha do usuário em questão");
                
            builder.Property(u => u.UsaSenha)
                .HasComment("informa se a API vai exigir a senha desse usuário nas conexões");

            builder.Property(u => u.Ativo)
                .HasComment("informa se o usuário está ativo na API");
        }
    }
}
