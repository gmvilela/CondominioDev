using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominioDev.Migrations
{
    public partial class AddRequiredAndIdDespesasAddRequiredAndIdReceitasAddRequiredAndIdHabitante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Receitas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Habitantes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Despesas",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Receitas",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Habitantes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Despesas",
                newName: "id");
        }
    }
}
