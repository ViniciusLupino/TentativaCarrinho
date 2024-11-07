using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoImpulseWebSite.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbCategoriaProduto_CategoriaProdutoIdCategoriaProduto",
                table: "tbProduto");

            migrationBuilder.DropIndex(
                name: "IX_tbProduto_CategoriaProdutoIdCategoriaProduto",
                table: "tbProduto");

            migrationBuilder.DropColumn(
                name: "CategoriaProdutoIdCategoriaProduto",
                table: "tbProduto");

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_CategoriaId",
                table: "tbProduto",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbCategoriaProduto_CategoriaId",
                table: "tbProduto",
                column: "CategoriaId",
                principalTable: "tbCategoriaProduto",
                principalColumn: "IdCategoriaProduto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbProduto_tbCategoriaProduto_CategoriaId",
                table: "tbProduto");

            migrationBuilder.DropIndex(
                name: "IX_tbProduto_CategoriaId",
                table: "tbProduto");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaProdutoIdCategoriaProduto",
                table: "tbProduto",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tbProduto_CategoriaProdutoIdCategoriaProduto",
                table: "tbProduto",
                column: "CategoriaProdutoIdCategoriaProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_tbProduto_tbCategoriaProduto_CategoriaProdutoIdCategoriaProduto",
                table: "tbProduto",
                column: "CategoriaProdutoIdCategoriaProduto",
                principalTable: "tbCategoriaProduto",
                principalColumn: "IdCategoriaProduto");
        }
    }
}
