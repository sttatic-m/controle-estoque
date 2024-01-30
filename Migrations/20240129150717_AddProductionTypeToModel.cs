using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace controle_estoque.Migrations
{
    /// <inheritdoc />
    public partial class AddProductionTypeToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Productions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Productions");
        }
    }
}
