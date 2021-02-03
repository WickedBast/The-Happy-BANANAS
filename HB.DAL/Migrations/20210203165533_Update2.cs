using Microsoft.EntityFrameworkCore.Migrations;

namespace HB.DAL.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Room",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Room",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Room");
        }
    }
}
