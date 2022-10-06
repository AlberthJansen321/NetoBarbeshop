using Microsoft.EntityFrameworkCore.Migrations;

namespace NetoBarbershop.Repository.Migrations
{
    public partial class _banco_quantidadeservicedoneproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "serviceDoneProducts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "serviceDoneProducts");
        }
    }
}
