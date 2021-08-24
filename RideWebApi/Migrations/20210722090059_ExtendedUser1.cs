using Microsoft.EntityFrameworkCore.Migrations;

namespace RideWebApi.Migrations
{
    public partial class ExtendedUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Appusers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "Appusers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
