using Microsoft.EntityFrameworkCore.Migrations;

namespace webshopApi.Migrations
{
    public partial class productAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Msrp = table.Column<decimal>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    picture = table.Column<string>(maxLength: 65535, nullable: true),
                    groupId = table.Column<int>(nullable: false),
                    brandId = table.Column<int>(nullable: false),
                    descriptionId = table.Column<int>(nullable: false),
                    pictureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_brandId",
                        column: x => x.brandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Groups_groupId",
                        column: x => x.groupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    productId = table.Column<int>(nullable: false),
                    descriptionName = table.Column<string>(maxLength: 255, nullable: true),
                    description = table.Column<string>(maxLength: 255, nullable: true),
                    descriptionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDescriptions_Products_descriptionId",
                        column: x => x.descriptionId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductDescriptions_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    idProd = table.Column<int>(nullable: false),
                    picutre = table.Column<string>(maxLength: 65535, nullable: true),
                    pictureId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Products_idProd",
                        column: x => x.idProd,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPictures_Products_pictureId",
                        column: x => x.pictureId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescriptions_descriptionId",
                table: "ProductDescriptions",
                column: "descriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDescriptions_productId",
                table: "ProductDescriptions",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_idProd",
                table: "ProductPictures",
                column: "idProd");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPictures_pictureId",
                table: "ProductPictures",
                column: "pictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_brandId",
                table: "Products",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_groupId",
                table: "Products",
                column: "groupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDescriptions");

            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
