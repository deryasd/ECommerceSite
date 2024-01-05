using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceSite.Services.Catalog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTblStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "Product",
                table: "Storage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                schema: "Product",
                table: "Storage",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
