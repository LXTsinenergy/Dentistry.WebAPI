using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dentistry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DayOfWeekAddition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkdayId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_WorkdayId",
                table: "Notes",
                column: "WorkdayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Days_WorkdayId",
                table: "Notes",
                column: "WorkdayId",
                principalTable: "Days",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Days_WorkdayId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Notes_WorkdayId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "WorkdayId",
                table: "Notes");
        }
    }
}
