using Microsoft.EntityFrameworkCore.Migrations;

namespace BingWebSearch.Migrations
{
    public partial class InitialCreateTableValue2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SavedImages",
                table: "SavedImages");

            migrationBuilder.RenameTable(
                name: "SavedImages",
                newName: "SaveUrlInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaveUrlInfo",
                table: "SaveUrlInfo",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SaveUrlInfo",
                table: "SaveUrlInfo");

            migrationBuilder.RenameTable(
                name: "SaveUrlInfo",
                newName: "SavedImages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SavedImages",
                table: "SavedImages",
                column: "id");
        }
    }
}
