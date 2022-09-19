using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CondominioDev.Migrations
{
    public partial class DespesasAddNullableHabitanteIdReceitasAddNullableHabitanteIdHabitanteAddNullableDataNascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Habitantes_HabitanteId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Habitantes_HabitanteId",
                table: "Receitas");

            migrationBuilder.AlterColumn<int>(
                name: "HabitanteId",
                table: "Receitas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Habitantes",
                type: "Date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "HabitanteId",
                table: "Despesas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Habitantes_HabitanteId",
                table: "Despesas",
                column: "HabitanteId",
                principalTable: "Habitantes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Habitantes_HabitanteId",
                table: "Receitas",
                column: "HabitanteId",
                principalTable: "Habitantes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Despesas_Habitantes_HabitanteId",
                table: "Despesas");

            migrationBuilder.DropForeignKey(
                name: "FK_Receitas_Habitantes_HabitanteId",
                table: "Receitas");

            migrationBuilder.AlterColumn<int>(
                name: "HabitanteId",
                table: "Receitas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Habitantes",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "Date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HabitanteId",
                table: "Despesas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Despesas_Habitantes_HabitanteId",
                table: "Despesas",
                column: "HabitanteId",
                principalTable: "Habitantes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receitas_Habitantes_HabitanteId",
                table: "Receitas",
                column: "HabitanteId",
                principalTable: "Habitantes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
