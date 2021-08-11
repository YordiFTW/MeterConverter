using Microsoft.EntityFrameworkCore.Migrations;

namespace test.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KeuzeMenu",
                table: "Calculations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeuzeMenu",
                table: "Calculations");
        }
    }
}
