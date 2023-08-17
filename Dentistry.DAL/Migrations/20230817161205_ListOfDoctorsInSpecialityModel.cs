using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dentistry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ListOfDoctorsInSpecialityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_Doctors_DoctorId",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_DoctorId",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Specialities");

            migrationBuilder.CreateTable(
                name: "DoctorSpeciality",
                columns: table => new
                {
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    SpecialtiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpeciality", x => new { x.DoctorsId, x.SpecialtiesId });
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorSpeciality_Specialities_SpecialtiesId",
                        column: x => x.SpecialtiesId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpeciality_SpecialtiesId",
                table: "DoctorSpeciality",
                column: "SpecialtiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpeciality");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Specialities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_DoctorId",
                table: "Specialities",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_Doctors_DoctorId",
                table: "Specialities",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
