using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class migracao_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Codigo = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "varchar(255)", nullable: true),
                    CodigoBarras = table.Column<string>(type: "varchar(255)", nullable: true),
                    NCM = table.Column<string>(type: "varchar(255)", nullable: true),
                    NCM_EX = table.Column<string>(type: "longtext", nullable: true),
                    CEST = table.Column<string>(type: "longtext", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioCadastro_codigo = table.Column<uint>(type: "int unsigned", nullable: false),
                    DataEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioEdicao_codigo = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "uf",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sigla = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarioapi",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "char(14)", fixedLength: true, maxLength: 14, nullable: false, comment: "CNPJ da empresa contratante do serviço"),
                    Token = table.Column<string>(type: "longtext", nullable: true, comment: "Armazena o token de acesso do usuário em questão"),
                    UF = table.Column<string>(type: "char(2)", fixedLength: true, maxLength: 2, nullable: false, comment: "informa UF que o token recebe as informações"),
                    Dados = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "Informa se a api retornará os dados adicionais do item nas consultas"),
                    Imagens = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "informa se a api irá retornar as imagens do item nas consultas"),
                    Senha = table.Column<string>(type: "char(32)", fixedLength: true, maxLength: 32, nullable: true, comment: "Informa a senha do usuário em questão"),
                    UsaSenha = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "informa se a API vai exigir a senha desse usuário nas conexões"),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "informa se o usuário está ativo na API")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarioapi", x => x.CNPJ);
                });

            migrationBuilder.CreateTable(
                name: "ItemICMS",
                columns: table => new
                {
                    Item_codigo = table.Column<uint>(type: "int unsigned", nullable: false),
                    UF = table.Column<string>(type: "varchar(255)", nullable: false),
                    ItemEntityCodigo = table.Column<uint>(type: "int unsigned", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemICMS", x => new { x.Item_codigo, x.UF });
                    table.ForeignKey(
                        name: "FK_ItemICMS_Item_ItemEntityCodigo",
                        column: x => x.ItemEntityCodigo,
                        principalTable: "Item",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPisCofins",
                columns: table => new
                {
                    Item_codigo = table.Column<uint>(type: "int unsigned", nullable: false),
                    CST = table.Column<string>(type: "longtext", nullable: true),
                    CodigoReceita = table.Column<string>(type: "longtext", nullable: true),
                    PPisCumulativo = table.Column<double>(type: "double", nullable: false),
                    PCofinsCumulativo = table.Column<double>(type: "double", nullable: false),
                    PPisCofinsCumulativo_FundamentoLegal = table.Column<string>(type: "longtext", nullable: true),
                    PPisNaoCumulativo = table.Column<double>(type: "double", nullable: false),
                    PCofinsNaoCumulativo = table.Column<double>(type: "double", nullable: false),
                    PPisCofinsNaoCumulativo_FundamentoLegal = table.Column<string>(type: "longtext", nullable: true),
                    DataEdicao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UsuarioEdicao_codigo = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPisCofins", x => x.Item_codigo);
                    table.ForeignKey(
                        name: "FK_ItemPisCofins_Item_Item_codigo",
                        column: x => x.Item_codigo,
                        principalTable: "Item",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "municipio",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodIBGE = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    UFId = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_municipio_uf_UFId",
                        column: x => x.UFId,
                        principalTable: "uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cep",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CEP = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    Numero = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    MunicipioId = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cep_municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "uf",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[,]
                {
                    { 11u, "Rondônia", "RO" },
                    { 51u, "Mato Grosso", "MT" },
                    { 50u, "Mato Grosso do Sul", "MS" },
                    { 43u, "Rio Grande do Sul", "RS" },
                    { 42u, "Santa Catarina", "SC" },
                    { 41u, "Paraná", "PR" },
                    { 35u, "São Paulo", "SP" },
                    { 33u, "Rio de Janeiro", "RJ" },
                    { 32u, "Espírito Santo", "ES" },
                    { 31u, "Minas Gerais", "MG" },
                    { 29u, "Bahia", "BA" },
                    { 28u, "Sergipe", "SE" },
                    { 52u, "Goiás", "GO" },
                    { 27u, "Alagoas", "AL" },
                    { 25u, "Paraíba", "PB" },
                    { 24u, "Rio Grande do Norte", "RN" },
                    { 23u, "Ceará", "CE" },
                    { 22u, "Piauí", "PI" },
                    { 21u, "Maranhão", "MA" },
                    { 17u, "Tocantins", "TO" },
                    { 16u, "Amapá", "AP" },
                    { 15u, "Pará", "PA" },
                    { 14u, "Roraima", "RR" },
                    { 13u, "Amazonas", "AM" },
                    { 12u, "Acre", "AC" },
                    { 26u, "Pernambuco", "PE" },
                    { 53u, "Distrito Federal", "DF" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_cep_CEP",
                table: "cep",
                column: "CEP");

            migrationBuilder.CreateIndex(
                name: "IX_cep_MunicipioId",
                table: "cep",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CodigoBarras",
                table: "Item",
                column: "CodigoBarras",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_DataCadastro",
                table: "Item",
                column: "DataCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_Item_DataEdicao",
                table: "Item",
                column: "DataEdicao");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Descricao",
                table: "Item",
                column: "Descricao");

            migrationBuilder.CreateIndex(
                name: "IX_Item_NCM",
                table: "Item",
                column: "NCM");

            migrationBuilder.CreateIndex(
                name: "IX_ItemICMS_ItemEntityCodigo",
                table: "ItemICMS",
                column: "ItemEntityCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_municipio_CodIBGE",
                table: "municipio",
                column: "CodIBGE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_municipio_UFId",
                table: "municipio",
                column: "UFId");

            migrationBuilder.CreateIndex(
                name: "IX_uf_Sigla",
                table: "uf",
                column: "Sigla",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cep");

            migrationBuilder.DropTable(
                name: "ItemICMS");

            migrationBuilder.DropTable(
                name: "ItemPisCofins");

            migrationBuilder.DropTable(
                name: "usuarioapi");

            migrationBuilder.DropTable(
                name: "municipio");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "uf");
        }
    }
}
