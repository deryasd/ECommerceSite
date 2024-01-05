using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ECommerceSite.Services.Catalog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddTblProductStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Storage_StorageId",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_StorageId",
                schema: "Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Stock",
                schema: "Product",
                table: "Storage");

            migrationBuilder.DropColumn(
                name: "StorageId",
                schema: "Product",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductStock",
                schema: "Product",
                columns: table => new
                {
                    ProductStorageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StorageId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => x.ProductStorageId);
                    table.ForeignKey(
                        name: "FK_ProductStock_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Product",
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStock_Storage_StorageId",
                        column: x => x.StorageId,
                        principalSchema: "Product",
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                schema: "Product",
                table: "ProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_StorageId",
                schema: "Product",
                table: "ProductStock",
                column: "StorageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductStock",
                schema: "Product");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                schema: "Product",
                table: "Storage",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StorageId",
                schema: "Product",
                table: "Product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_StorageId",
                schema: "Product",
                table: "Product",
                column: "StorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Storage_StorageId",
                schema: "Product",
                table: "Product",
                column: "StorageId",
                principalSchema: "Product",
                principalTable: "Storage",
                principalColumn: "StorageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
