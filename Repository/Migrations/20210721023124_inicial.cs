using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apolice",
                columns: table => new
                {
                    IdApolice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataCancelamento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apolice", x => x.IdApolice);
                });

            migrationBuilder.CreateTable(
                name: "ApoliceVida",
                columns: table => new
                {
                    IdApoliceVida = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdApolice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdVida = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApoliceVida", x => x.IdApoliceVida);
                });

            migrationBuilder.CreateTable(
                name: "Vida",
                columns: table => new
                {
                    IdVida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoResidencial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoComercial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profissao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSeguradoPrincipal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vida", x => x.IdVida);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apolice");

            migrationBuilder.DropTable(
                name: "ApoliceVida");

            migrationBuilder.DropTable(
                name: "Vida");
        }
    }
}
