using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controle_estoque.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Products_ProductId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Recipes_RecipeId",
                table: "Productions");

            migrationBuilder.DropIndex(
                name: "IX_Productions_ProductId",
                table: "Productions");

            migrationBuilder.DropIndex(
                name: "IX_Productions_RecipeId",
                table: "Productions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Productions");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Productions");

            migrationBuilder.AddColumn<int>(
                name: "ProductCode",
                table: "Productions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecipeCode",
                table: "Productions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Productions");

            migrationBuilder.DropColumn(
                name: "RecipeCode",
                table: "Productions");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Productions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "Productions",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productions_ProductId",
                table: "Productions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Productions_RecipeId",
                table: "Productions",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_Products_ProductId",
                table: "Productions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_Recipes_RecipeId",
                table: "Productions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
