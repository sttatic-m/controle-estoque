using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controle_estoque.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbSetModels : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Recipes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "Productions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Productions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Productions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Products_ProductId",
                table: "Productions");

            migrationBuilder.DropForeignKey(
                name: "FK_Productions_Recipes_RecipeId",
                table: "Productions");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Productions");

            migrationBuilder.AlterColumn<Guid>(
                name: "RecipeId",
                table: "Productions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductId",
                table: "Productions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

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
    }
}
