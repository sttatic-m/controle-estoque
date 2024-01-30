using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controle_estoque.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductCodes",
                table: "Productions",
                newName: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Products",
                table: "Productions",
                newName: "ProductCodes");
        }
    }
}
