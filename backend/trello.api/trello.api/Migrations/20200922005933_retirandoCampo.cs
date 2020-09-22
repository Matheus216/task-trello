using Microsoft.EntityFrameworkCore.Migrations;

namespace trello.api.Migrations
{
    public partial class retirandoCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskCheck");

            migrationBuilder.AddColumn<int>(
                name: "TaskEntityModelTaskId",
                table: "Check",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Check",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Check_TaskEntityModelTaskId",
                table: "Check",
                column: "TaskEntityModelTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Check_Task_TaskEntityModelTaskId",
                table: "Check",
                column: "TaskEntityModelTaskId",
                principalTable: "Task",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Check_Task_TaskEntityModelTaskId",
                table: "Check");

            migrationBuilder.DropIndex(
                name: "IX_Check_TaskEntityModelTaskId",
                table: "Check");

            migrationBuilder.DropColumn(
                name: "TaskEntityModelTaskId",
                table: "Check");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Check");

            migrationBuilder.CreateTable(
                name: "TaskCheck",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    CheckId = table.Column<int>(type: "int", nullable: false),
                    PanelEntityModelPanelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskCheck", x => new { x.TaskId, x.CheckId });
                    table.ForeignKey(
                        name: "FK_TaskCheck_Check_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Check",
                        principalColumn: "CheckId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskCheck_Panel_PanelEntityModelPanelId",
                        column: x => x.PanelEntityModelPanelId,
                        principalTable: "Panel",
                        principalColumn: "PanelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskCheck_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskCheck_CheckId",
                table: "TaskCheck",
                column: "CheckId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskCheck_PanelEntityModelPanelId",
                table: "TaskCheck",
                column: "PanelEntityModelPanelId");
        }
    }
}
