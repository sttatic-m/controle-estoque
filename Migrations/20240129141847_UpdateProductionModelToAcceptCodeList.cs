using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controle_estoque.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductionModelToAcceptCodeList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Productions");

            migrationBuilder.AddColumn<string>(
                name: "ProductCodes",
                table: "Productions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCodes",
                table: "Productions");

            migrationBuilder.AddColumn<int>(
                name: "ProductCode",
                table: "Productions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
