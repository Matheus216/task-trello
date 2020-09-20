using Microsoft.EntityFrameworkCore.Migrations;

namespace trello.api.Migrations
{
    public partial class AlterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Panel_PanelId",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "PanelId",
                table: "Task",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Task",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Check",
                columns: table => new
                {
                    CheckId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    IsChecked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Check", x => x.CheckId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TaskCheck",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    CheckId = table.Column<int>(nullable: false),
                    PanelEntityModelPanelId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "TaskUser",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskUser", x => new { x.TaskId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TaskUser_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_TaskUser_UserId",
                table: "TaskUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Panel_PanelId",
                table: "Task",
                column: "PanelId",
                principalTable: "Panel",
                principalColumn: "PanelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Panel_PanelId",
                table: "Task");

            migrationBuilder.DropTable(
                name: "TaskCheck");

            migrationBuilder.DropTable(
                name: "TaskUser");

            migrationBuilder.DropTable(
                name: "Check");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Task");

            migrationBuilder.AlterColumn<int>(
                name: "PanelId",
                table: "Task",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Panel_PanelId",
                table: "Task",
                column: "PanelId",
                principalTable: "Panel",
                principalColumn: "PanelId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
