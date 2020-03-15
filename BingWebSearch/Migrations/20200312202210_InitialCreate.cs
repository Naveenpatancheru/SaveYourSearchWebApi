using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BingWebSearch.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "userid",
            //    table: "SaveUrlInfo",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    noteId = table.Column<string>(nullable: false),
                    noteHeadLine = table.Column<string>(nullable: true),
                    notesInfo = table.Column<string>(nullable: true),
                    createdDate = table.Column<DateTime>(nullable: false),
                    moreInfo = table.Column<string>(nullable: true),
                    bufferColumn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.noteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Note");

            //migrationBuilder.DropColumn(
            //    name: "userid",
            //    table: "SaveUrlInfo");
        }
    }
}
