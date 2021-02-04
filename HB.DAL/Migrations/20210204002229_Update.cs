using Microsoft.EntityFrameworkCore.Migrations;

namespace HB.DAL.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cost",
                table: "ExtraService",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Cost",
                table: "ExtraService",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
