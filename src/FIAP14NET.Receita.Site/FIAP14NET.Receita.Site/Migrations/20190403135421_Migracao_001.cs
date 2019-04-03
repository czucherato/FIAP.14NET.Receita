using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIAP14NET.Receita.Site.Migrations
{
    public partial class Migracao_001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 300, nullable: true),
                    ModoDePreparo = table.Column<string>(type: "varchar", maxLength: 3000, nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    Unidade = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_ReceitaId",
                table: "Ingrediente",
                column: "ReceitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Receita");
        }
    }
}
