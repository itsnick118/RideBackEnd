using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RideWebApi.Migrations
{
    public partial class Bookin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "endDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "startDate",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "endDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "startDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
