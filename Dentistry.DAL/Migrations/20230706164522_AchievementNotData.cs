using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dentistry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AchievementNotData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Achievements");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements",
                column: "DoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements",
                column: "DoctorId",
                unique: true);
        }
    }
}
