using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceSite.Services.Catalog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelBuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                schema: "Product",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryId",
                schema: "Product",
                table: "Product",
                column: "CategoryId",
                principalSchema: "Product",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryId",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                schema: "Product",
                table: "Product");
        }
    }
}
