using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dentistry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AchvievementOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements",
                column: "DoctorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DoctorId",
                table: "Achievements",
                column: "DoctorId");
        }
    }
}
