using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimplyDeliciousBarEvents.Migrations
{
    public partial class InitialSetup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeViewModel_EventSheetViewModel_EventSheetViewModelEventSheetID",
                table: "EmployeeViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EventSheetViewModel_ClientViewModel_ClientID",
                table: "EventSheetViewModel");

            migrationBuilder.DropIndex(
                name: "IX_EventSheetViewModel_ClientID",
                table: "EventSheetViewModel");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeViewModel_EventSheetViewModelEventSheetID",
                table: "EmployeeViewModel");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "EventSheetViewModel");

            migrationBuilder.DropColumn(
                name: "EventSheetViewModelEventSheetID",
                table: "EmployeeViewModel");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EventTime",
                table: "EventSheetViewModel",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "EventSheetViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientContactNumber",
                table: "EventSheetViewModel",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Employee",
                table: "EventSheetViewModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "EventSheetViewModel");

            migrationBuilder.DropColumn(
                name: "ClientContactNumber",
                table: "EventSheetViewModel");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "EventSheetViewModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventTime",
                table: "EventSheetViewModel",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "EventSheetViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventSheetViewModelEventSheetID",
                table: "EmployeeViewModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventSheetViewModel_ClientID",
                table: "EventSheetViewModel",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeViewModel_EventSheetViewModelEventSheetID",
                table: "EmployeeViewModel",
                column: "EventSheetViewModelEventSheetID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeViewModel_EventSheetViewModel_EventSheetViewModelEventSheetID",
                table: "EmployeeViewModel",
                column: "EventSheetViewModelEventSheetID",
                principalTable: "EventSheetViewModel",
                principalColumn: "EventSheetID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventSheetViewModel_ClientViewModel_ClientID",
                table: "EventSheetViewModel",
                column: "ClientID",
                principalTable: "ClientViewModel",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
