using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FIAP14NET.Receita.Site.Migrations
{
    public partial class Migracao_003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediente_Receita_ReceitaId",
                table: "Ingrediente");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_ReceitaId",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "ReceitaId",
                table: "Ingrediente");

            migrationBuilder.CreateTable(
                name: "IngredienteReceita",
                columns: table => new
                {
                    IngredienteId = table.Column<Guid>(nullable: false),
                    ReceitaId = table.Column<Guid>(nullable: false),
                    Quantidade = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteReceita", x => new { x.IngredienteId, x.ReceitaId });
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteReceita_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteReceita_ReceitaId",
                table: "IngredienteReceita",
                column: "ReceitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredienteReceita");

            migrationBuilder.AddColumn<Guid>(
                name: "ReceitaId",
                table: "Ingrediente",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_ReceitaId",
                table: "Ingrediente",
                column: "ReceitaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrediente_Receita_ReceitaId",
                table: "Ingrediente",
                column: "ReceitaId",
                principalTable: "Receita",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
