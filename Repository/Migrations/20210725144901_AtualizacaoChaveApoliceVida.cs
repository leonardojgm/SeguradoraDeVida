using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class AtualizacaoChaveApoliceVida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdVida",
                table: "ApoliceVida",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "IdApolice",
                table: "ApoliceVida",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.DropColumn(
                name: "IdApoliceVida",
                table: "ApoliceVida");

            migrationBuilder.AddColumn<int>(
                name: "IdApoliceVida",
                table: "ApoliceVida",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdVida",
                table: "ApoliceVida",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IdApolice",
                table: "ApoliceVida",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.DropColumn(
                name: "IdApoliceVida",
                table: "ApoliceVida");

            migrationBuilder.AddColumn<int>(
                name: "IdApoliceVida",
                table: "ApoliceVida",
                type: "nvarchar(450)",
                nullable: true);
        }
    }
}
