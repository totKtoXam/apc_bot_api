using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apc_bot_api.Migrations
{
    public partial class CommandFileFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandFiles",
                table: "CommandFiles");

            migrationBuilder.DropColumn(
                name: "UploadedFileId",
                table: "CommandFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandFiles",
                table: "CommandFiles",
                columns: new[] { "CommandId", "FileId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandFiles",
                table: "CommandFiles");

            migrationBuilder.AddColumn<Guid>(
                name: "UploadedFileId",
                table: "CommandFiles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandFiles",
                table: "CommandFiles",
                columns: new[] { "CommandId", "UploadedFileId" });
        }
    }
}
