using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyDeliciousBarEvents.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventSheetViewModel",
                columns: table => new
                {
                    EventSheetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(nullable: true),
                    EventDate = table.Column<DateTime>(nullable: false),
                    EventTime = table.Column<DateTime>(nullable: false),
                    HeadCount = table.Column<int>(nullable: false),
                    EventCost = table.Column<float>(nullable: false),
                    ClientID = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventSheetViewModel", x => x.EventSheetID);
                });

            migrationBuilder.CreateTable(
                name: "ClientViewModel",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactNumber = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PrimaryOrSecondaryContact = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EventSheetViewModelEventSheetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientViewModel", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_ClientViewModel_EventSheetViewModel_EventSheetViewModelEventSheetID",
                        column: x => x.EventSheetViewModelEventSheetID,
                        principalTable: "EventSheetViewModel",
                        principalColumn: "EventSheetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuViewModel",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeverageName = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Servings = table.Column<int>(nullable: false),
                    EventSheetViewModelEventSheetID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuViewModel", x => x.MenuID);
                    table.ForeignKey(
                        name: "FK_MenuViewModel_EventSheetViewModel_EventSheetViewModelEventSheetID",
                        column: x => x.EventSheetViewModelEventSheetID,
                        principalTable: "EventSheetViewModel",
                        principalColumn: "EventSheetID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientViewModel_EventSheetViewModelEventSheetID",
                table: "ClientViewModel",
                column: "EventSheetViewModelEventSheetID");

            migrationBuilder.CreateIndex(
                name: "IX_EventSheetViewModel_ClientID",
                table: "EventSheetViewModel",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuViewModel_EventSheetViewModelEventSheetID",
                table: "MenuViewModel",
                column: "EventSheetViewModelEventSheetID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSheetViewModel_ClientViewModel_ClientID",
                table: "EventSheetViewModel",
                column: "ClientID",
                principalTable: "ClientViewModel",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientViewModel_EventSheetViewModel_EventSheetViewModelEventSheetID",
                table: "ClientViewModel");

            migrationBuilder.DropTable(
                name: "MenuViewModel");

            migrationBuilder.DropTable(
                name: "EventSheetViewModel");

            migrationBuilder.DropTable(
                name: "ClientViewModel");
        }
    }
}
