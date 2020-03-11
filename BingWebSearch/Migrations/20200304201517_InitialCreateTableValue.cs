using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BingWebSearch.Migrations
{
    public partial class InitialCreateTableValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SavedImages",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    displayUrl = table.Column<string>(nullable: true),
                    snippet = table.Column<string>(nullable: true),
                    dateLastCrawled = table.Column<DateTime>(nullable: false),
                    language = table.Column<string>(nullable: true),
                    isNavigational = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedImages", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SavedImages");
        }
    }
}
