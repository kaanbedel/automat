using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Automat.Persistence.Migrations
{
    public partial class AutomatTablesAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertUserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CategoryType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    InsertUserId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ProductCode = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "InsertDate", "InsertUserId", "Name" },
                values: new object[] { 1, 0, new DateTime(2021, 1, 17, 14, 20, 37, 692, DateTimeKind.Local), 1, "İçecek" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "InsertDate", "InsertUserId", "Name" },
                values: new object[] { 2, 2, new DateTime(2021, 1, 17, 14, 20, 37, 694, DateTimeKind.Local), 1, "Yiyecek" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryType", "InsertDate", "InsertUserId", "Name" },
                values: new object[] { 3, 1, new DateTime(2021, 1, 17, 14, 20, 37, 694, DateTimeKind.Local), 1, "Sıcak İçecek" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InsertDate", "InsertUserId", "Name", "Price", "ProductCode", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Su", 1.0, 100, 10 },
                    { 2, 1, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Meyve Suyu", 2.0, 200, 10 },
                    { 3, 1, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Cola", 3.0, 300, 10 },
                    { 6, 2, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Et", 20.0, 1000, 5 },
                    { 7, 2, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Balık", 15.0, 2000, 5 },
                    { 8, 2, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Sandviç", 10.0, 3000, 5 },
                    { 4, 3, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Çay", 4.0, 400, 20 },
                    { 5, 3, new DateTime(2021, 1, 17, 14, 20, 37, 696, DateTimeKind.Local), 1, "Kahve", 5.0, 500, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
