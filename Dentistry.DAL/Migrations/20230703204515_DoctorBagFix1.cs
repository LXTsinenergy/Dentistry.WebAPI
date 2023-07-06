using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dentistry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class DoctorBagFix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Doctors_DoctorId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Reviews");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Doctors_DoctorId",
                table: "Reviews",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
