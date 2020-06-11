using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace apc_bot_api.Migrations
{
    public partial class Specialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Short = table.Column<string>(nullable: true),
                    SpecialtyNum = table.Column<string>(nullable: true),
                    SpecialtyName = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    ClassificName = table.Column<string>(nullable: true),
                    Languages = table.Column<string>(nullable: true),
                    StudyType = table.Column<string>(nullable: true),
                    StudyPeriod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specialities");
        }
    }
}
