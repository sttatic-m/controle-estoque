using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controle_estoque.Migrations
{
    /// <inheritdoc />
    public partial class SepareteStepFromProductsInProductionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Products",
                table: "Productions",
                newName: "StepProducts");

            migrationBuilder.AddColumn<int>(
                name: "Product",
                table: "Productions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product",
                table: "Productions");

            migrationBuilder.RenameColumn(
                name: "StepProducts",
                table: "Productions",
                newName: "Products");
        }
    }
}
