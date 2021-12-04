using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheVideoGameStore.Inventory.Infastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "platform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_platform", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_platform_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "platform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_productType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "productType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "platform",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "XboxOne" },
                    { 2, "XboxSeriesX" },
                    { 3, "Playstation4" },
                    { 4, "Playstation5" },
                    { 5, "NintendoSwitch" },
                    { 6, "PC" }
                });

            migrationBuilder.InsertData(
                table: "productType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Console" },
                    { 2, "VideoGame" },
                    { 3, "Accessory" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_PlatformId",
                table: "product",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductTypeId",
                table: "product",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "platform");

            migrationBuilder.DropTable(
                name: "productType");
        }
    }
}
