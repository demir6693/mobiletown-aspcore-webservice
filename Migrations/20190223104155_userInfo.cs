using Microsoft.EntityFrameworkCore.Migrations;

namespace webshopApi.Migrations
{
    public partial class userInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IdUser = table.Column<int>(nullable: false),
                    fName = table.Column<string>(maxLength: 255, nullable: true),
                    lName = table.Column<string>(maxLength: 255, nullable: true),
                    userName = table.Column<string>(maxLength: 255, nullable: true),
                    adresa = table.Column<string>(maxLength: 255, nullable: true),
                    grad = table.Column<string>(maxLength: 255, nullable: true),
                    postalCode = table.Column<int>(nullable: false),
                    brTelefona = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    IdUserInfo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UsersInfo_IdUserInfo",
                        column: x => x.IdUserInfo,
                        principalTable: "UsersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_IdUserInfo",
                table: "User",
                column: "IdUserInfo");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfo_IdUser",
                table: "UsersInfo",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersInfo_User_IdUser",
                table: "UsersInfo",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UsersInfo_IdUserInfo",
                table: "User");

            migrationBuilder.DropTable(
                name: "UsersInfo");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
