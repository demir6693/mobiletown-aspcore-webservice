using Microsoft.EntityFrameworkCore.Migrations;

namespace webshopApi.Migrations
{
    public partial class stringUTF16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "picture",
                table: "ProductPictures",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 65535,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "picture",
                table: "ProductPictures",
                maxLength: 65535,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
