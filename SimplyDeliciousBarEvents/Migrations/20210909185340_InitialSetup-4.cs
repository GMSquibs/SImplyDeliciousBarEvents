using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyDeliciousBarEvents.Migrations
{
    public partial class InitialSetup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "EventViewModel");

            migrationBuilder.AddColumn<string>(
                name: "LocationID",
                table: "EventViewModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationID",
                table: "EventViewModel");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "EventViewModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
