using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Infra.Data.Migrations
{
    public partial class Projeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    IDCLIENTE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(maxLength: 100, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    DATACADASTRO = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.IDCLIENTE);
                });

            migrationBuilder.CreateTable(
                name: "DEPENDENTE",
                columns: table => new
                {
                    IDDEPENDENTE = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(maxLength: 150, nullable: false),
                    DATANASCIMENTO = table.Column<DateTime>(nullable: false),
                    IDCLIENTE = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEPENDENTE", x => x.IDDEPENDENTE);
                    table.ForeignKey(
                        name: "FK_DEPENDENTE_CLIENTE_IDCLIENTE",
                        column: x => x.IDCLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DEPENDENTE_IDCLIENTE",
                table: "DEPENDENTE",
                column: "IDCLIENTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DEPENDENTE");

            migrationBuilder.DropTable(
                name: "CLIENTE");
        }
    }
}
