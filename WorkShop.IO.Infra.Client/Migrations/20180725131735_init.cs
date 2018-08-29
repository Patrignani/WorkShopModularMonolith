using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkShop.IO.Infra.Client.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogged",
                columns: table => new
                {
                    CascadeMode = table.Column<int>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    DataLogged = table.Column<DateTime>(nullable: false),
                    DataCheck = table.Column<DateTime>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogged", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    CascadeMode = table.Column<int>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Identification = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    LastInteraction = table.Column<DateTime>(nullable: false),
                    UserLoggedId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserLogged_UserLoggedId",
                        column: x => x.UserLoggedId,
                        principalTable: "UserLogged",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Identification",
                table: "User",
                column: "Identification",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserLoggedId",
                table: "User",
                column: "UserLoggedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserLogged");
        }
    }
}
