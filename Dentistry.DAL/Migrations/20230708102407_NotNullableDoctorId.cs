using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dentistry.DAL.Migrations
{
    /// <inheritdoc />
    public partial class NotNullableDoctorId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Doctors_DoctorId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Doctors_DoctorId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Doctors_DoctorId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacesOfWork_Doctors_DoctorId",
                table: "PlacesOfWork");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "PlacesOfWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Doctors_DoctorId",
                table: "Achievements",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Doctors_DoctorId",
                table: "Certificates",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Doctors_DoctorId",
                table: "Educations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlacesOfWork_Doctors_DoctorId",
                table: "PlacesOfWork",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Doctors_DoctorId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Doctors_DoctorId",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Doctors_DoctorId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacesOfWork_Doctors_DoctorId",
                table: "PlacesOfWork");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "PlacesOfWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Educations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Certificates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Achievements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Doctors_DoctorId",
                table: "Achievements",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Doctors_DoctorId",
                table: "Certificates",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Doctors_DoctorId",
                table: "Educations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacesOfWork_Doctors_DoctorId",
                table: "PlacesOfWork",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");
        }
    }
}
