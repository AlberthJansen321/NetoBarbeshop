using Microsoft.EntityFrameworkCore.Migrations;

namespace NetoBarbershop.Repository.Migrations
{
    public partial class _bancogojeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Gojeta",
                table: "ServicesDones",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gojeta",
                table: "ServicesDones");
        }
    }
}
