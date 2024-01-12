using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controle_estoque.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSetForRecipesAndProductionbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId",
                table: "Productions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productions_Recipes_RecipeId",
                table: "Productions",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
