using Microsoft.EntityFrameworkCore.Migrations;

namespace trello.api.Migrations
{
    public partial class AjustContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PanelId",
                table: "Painting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PanelId",
                table: "Painting",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
