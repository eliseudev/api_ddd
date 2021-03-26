using DDDAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DDDAPI.Data.Seeds
{
    /** 
    Seeds é uma palavra muito usada quando deseja semear/cadastrar (Seeds = Sementes) algo
    de forma automatica no banco de dados ao realizar as migrações.
    */
    public class UFSeeds
    {
        public static void PovoarUFs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UFEntity>().HasData(
                new UFEntity
                {
                    Id = 11,
                    Nome = "Rondônia",
                    Sigla = "RO"
                },
                new UFEntity
                {
                    Id = 12,
                    Nome = "Acre",
                    Sigla = "AC"
                },
                new UFEntity
                {
                    Id = 13,
                    Nome = "Amazonas",
                    Sigla = "AM"
                },
                new UFEntity
                {
                    Id = 14,
                    Nome = "Roraima",
                    Sigla = "RR"
                },
                new UFEntity
                {
                    Id = 15,
                    Nome = "Pará",
                    Sigla = "PA"
                },
                new UFEntity
                {
                    Id = 16,
                    Nome = "Amapá",
                    Sigla = "AP"
                },
                new UFEntity
                {
                    Id = 17,
                    Nome = "Tocantins",
                    Sigla = "TO"
                },
                new UFEntity
                {
                    Id = 21,
                    Nome = "Maranhão",
                    Sigla = "MA"
                },
                new UFEntity
                {
                    Id = 22,
                    Nome = "Piauí",
                    Sigla = "PI"
                },
                new UFEntity
                {
                    Id = 23,
                    Nome = "Ceará",
                    Sigla = "CE"
                },
                new UFEntity
                {
                    Id = 24,
                    Nome = "Rio Grande do Norte",
                    Sigla = "RN"
                },
                new UFEntity
                {
                    Id = 25,
                    Nome = "Paraíba",
                    Sigla = "PB"
                },
                new UFEntity
                {
                    Id = 26,
                    Nome = "Pernambuco",
                    Sigla = "PE"
                },
                new UFEntity
                {
                    Id = 27,
                    Nome = "Alagoas",
                    Sigla = "AL"
                },
                new UFEntity
                {
                    Id = 28,
                    Nome = "Sergipe",
                    Sigla = "SE"
                },
                new UFEntity
                {
                    Id = 29,
                    Nome = "Bahia",
                    Sigla = "BA"
                },
                new UFEntity
                {
                    Id = 31,
                    Nome = "Minas Gerais",
                    Sigla = "MG"
                },
                new UFEntity
                {
                    Id = 32,
                    Nome = "Espírito Santo",
                    Sigla = "ES"
                },
                new UFEntity
                {
                    Id = 33,
                    Nome = "Rio de Janeiro",
                    Sigla = "RJ"
                },
                new UFEntity
                {
                    Id = 35,
                    Nome = "São Paulo",
                    Sigla = "SP"
                },
                new UFEntity
                {
                    Id = 41,
                    Nome = "Paraná",
                    Sigla = "PR"
                },
                new UFEntity
                {
                    Id = 42,
                    Nome = "Santa Catarina",
                    Sigla = "SC"
                },
                new UFEntity
                {
                    Id = 43,
                    Nome = "Rio Grande do Sul",
                    Sigla = "RS"
                },
                new UFEntity
                {
                    Id = 50,
                    Nome = "Mato Grosso do Sul",
                    Sigla = "MS"
                },
                new UFEntity
                {
                    Id = 51,
                    Nome = "Mato Grosso",
                    Sigla = "MT"
                },
                new UFEntity
                {
                    Id = 52,
                    Nome = "Goiás",
                    Sigla = "GO"
                },
                new UFEntity
                {
                    Id = 53,
                    Nome = "Distrito Federal",
                    Sigla = "DF"
                }
            );
        }
    }
}
