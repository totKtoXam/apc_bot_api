using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apc_bot_api.Migrations
{
    public partial class TaskFinishDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finish",
                table: "AssignedTasks");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "AssignedTasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishDate",
                table: "AssignedTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "AssignedTasks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishDate",
                table: "AssignedTasks");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "AssignedTasks");

            migrationBuilder.AddColumn<DateTime>(
                name: "Finish",
                table: "AssignedTasks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "AssignedTasks",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
