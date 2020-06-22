using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class projeto02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SEXO",
                table: "DEPENDENTE",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DATANASCIMENTO",
                table: "CLIENTE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "TELEFONE",
                table: "CLIENTE",
                maxLength: 25,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SEXO",
                table: "DEPENDENTE");

            migrationBuilder.DropColumn(
                name: "DATANASCIMENTO",
                table: "CLIENTE");

            migrationBuilder.DropColumn(
                name: "TELEFONE",
                table: "CLIENTE");
        }
    }
}
