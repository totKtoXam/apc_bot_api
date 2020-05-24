using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace apc_bot_api.Migrations
{
    public partial class NewDbStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SectionFiles");

            migrationBuilder.DropTable(
                name: "SectionRoles");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.AddColumn<Guid>(
                name: "FileId",
                table: "UploadedFiles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UploadedById",
                table: "UploadedFiles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadedDate",
                table: "UploadedFiles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextStepCode",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrevStepCode",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Steps",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CurrnetStepId",
                table: "BotActions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnrolleeAppeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    SentById = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolleeAppeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrolleeAppeals_AspNetUsers_SentById",
                        column: x => x.SentById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StepFiles",
                columns: table => new
                {
                    StepId = table.Column<Guid>(nullable: false),
                    UploadedFileId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepFiles", x => new { x.StepId, x.UploadedFileId });
                    table.ForeignKey(
                        name: "FK_StepFiles_UploadedFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepFiles_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepRoles",
                columns: table => new
                {
                    StepId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepRoles", x => new { x.StepId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_StepRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepRoles_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrolleeAppealFiles",
                columns: table => new
                {
                    AppealId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<int>(nullable: false),
                    AppealId1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolleeAppealFiles", x => new { x.AppealId, x.FileId });
                    table.ForeignKey(
                        name: "FK_EnrolleeAppealFiles_EnrolleeAppeals_AppealId1",
                        column: x => x.AppealId1,
                        principalTable: "EnrolleeAppeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolleeAppealFiles_UploadedFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: true),
                    StepId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informations_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Informations_InfoTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "InfoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InfoFiles",
                columns: table => new
                {
                    InfoId = table.Column<Guid>(nullable: false),
                    FileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoFiles", x => new { x.InfoId, x.FileId });
                    table.ForeignKey(
                        name: "FK_InfoFiles_UploadedFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InfoFiles_Informations_InfoId",
                        column: x => x.InfoId,
                        principalTable: "Informations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_FileId",
                table: "UploadedFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UploadedById",
                table: "UploadedFiles",
                column: "UploadedById");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TypeId",
                table: "Steps",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BotActions_CurrnetStepId",
                table: "BotActions",
                column: "CurrnetStepId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolleeAppealFiles_AppealId1",
                table: "EnrolleeAppealFiles",
                column: "AppealId1");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolleeAppealFiles_FileId",
                table: "EnrolleeAppealFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolleeAppeals_SentById",
                table: "EnrolleeAppeals",
                column: "SentById");

            migrationBuilder.CreateIndex(
                name: "IX_InfoFiles_FileId",
                table: "InfoFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_StepId",
                table: "Informations",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_Informations_TypeId",
                table: "Informations",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StepFiles_FileId",
                table: "StepFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_StepRoles_RoleId",
                table: "StepRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BotActions_Steps_CurrnetStepId",
                table: "BotActions",
                column: "CurrnetStepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_StepTypes_TypeId",
                table: "Steps",
                column: "TypeId",
                principalTable: "StepTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_FileTypes_FileId",
                table: "UploadedFiles",
                column: "FileId",
                principalTable: "FileTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_UploadedById",
                table: "UploadedFiles",
                column: "UploadedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotActions_Steps_CurrnetStepId",
                table: "BotActions");

            migrationBuilder.DropForeignKey(
                name: "FK_Steps_StepTypes_TypeId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_FileTypes_FileId",
                table: "UploadedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_UploadedById",
                table: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "EnrolleeAppealFiles");

            migrationBuilder.DropTable(
                name: "FileTypes");

            migrationBuilder.DropTable(
                name: "InfoFiles");

            migrationBuilder.DropTable(
                name: "StepFiles");

            migrationBuilder.DropTable(
                name: "StepRoles");

            migrationBuilder.DropTable(
                name: "StepTypes");

            migrationBuilder.DropTable(
                name: "EnrolleeAppeals");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "InfoTypes");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_FileId",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UploadedById",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_Steps_TypeId",
                table: "Steps");

            migrationBuilder.DropIndex(
                name: "IX_BotActions_CurrnetStepId",
                table: "BotActions");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "UploadedById",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "UploadedDate",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "NextStepCode",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "PrevStepCode",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "CurrnetStepId",
                table: "BotActions");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    NameTitle = table.Column<string>(type: "text", nullable: true),
                    ParentSection = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectionFiles",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    UploadedFileId = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionFiles", x => new { x.SectionId, x.UploadedFileId });
                    table.ForeignKey(
                        name: "FK_SectionFiles_UploadedFiles_FileId",
                        column: x => x.FileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionFiles_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectionRoles",
                columns: table => new
                {
                    SectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionRoles", x => new { x.SectionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_SectionRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SectionRoles_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SectionFiles_FileId",
                table: "SectionFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionRoles_RoleId",
                table: "SectionRoles",
                column: "RoleId");
        }
    }
}
