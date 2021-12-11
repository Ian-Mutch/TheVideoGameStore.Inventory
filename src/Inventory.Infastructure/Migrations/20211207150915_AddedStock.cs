using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheVideoGameStore.Inventory.Infastructure.Migrations
{
    public partial class AddedStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "condition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ConditionId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stock_condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "condition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stock_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "condition",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "New" });

            migrationBuilder.InsertData(
                table: "condition",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Preowned" });

            migrationBuilder.CreateIndex(
                name: "IX_stock_ConditionId",
                table: "stock",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_stock_ProductId",
                table: "stock",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "condition");
        }
    }
}
