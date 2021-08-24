using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RideWebApi.Migrations
{
    public partial class extend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appusers_Photo_PhotosId",
                table: "Appusers");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Appusers_PhotosId",
                table: "Appusers");

            migrationBuilder.DropColumn(
                name: "PhotosId",
                table: "Appusers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Appusers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Appusers");

            migrationBuilder.AddColumn<int>(
                name: "PhotosId",
                table: "Appusers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appusers_PhotosId",
                table: "Appusers",
                column: "PhotosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appusers_Photo_PhotosId",
                table: "Appusers",
                column: "PhotosId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
