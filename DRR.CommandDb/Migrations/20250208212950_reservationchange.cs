using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRR.CommandDb.Migrations
{
    /// <inheritdoc />
    public partial class reservationchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorTreatmentCenters_DoctorTreatmentCenterId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReservations_Turn_TurnId",
                table: "PatientReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_VisitTypes_VisitTypeId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Turn_Reservations_ReservationId",
                table: "Turn");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_VisitTypeId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorTreatmentCenterId",
                table: "Doctors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turn",
                table: "Turn");

            migrationBuilder.DropColumn(
                name: "VisitTypeId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DoctorTreatmentCenterId",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Turn",
                newName: "Turns");

            migrationBuilder.RenameIndex(
                name: "IX_Turn_ReservationId",
                table: "Turns",
                newName: "IX_Turns_ReservationId");

            migrationBuilder.AlterColumn<int>(
                name: "VisitTypeId",
                table: "VisitCosts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turns",
                table: "Turns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReservations_Turns_TurnId",
                table: "PatientReservations",
                column: "TurnId",
                principalTable: "Turns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turns_Reservations_ReservationId",
                table: "Turns",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReservations_Turns_TurnId",
                table: "PatientReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Turns_Reservations_ReservationId",
                table: "Turns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Turns",
                table: "Turns");

            migrationBuilder.RenameTable(
                name: "Turns",
                newName: "Turn");

            migrationBuilder.RenameIndex(
                name: "IX_Turns_ReservationId",
                table: "Turn",
                newName: "IX_Turn_ReservationId");

            migrationBuilder.AlterColumn<int>(
                name: "VisitTypeId",
                table: "VisitCosts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "VisitTypeId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoctorTreatmentCenterId",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Turn",
                table: "Turn",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VisitTypeId",
                table: "Reservations",
                column: "VisitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorTreatmentCenterId",
                table: "Doctors",
                column: "DoctorTreatmentCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorTreatmentCenters_DoctorTreatmentCenterId",
                table: "Doctors",
                column: "DoctorTreatmentCenterId",
                principalTable: "DoctorTreatmentCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReservations_Turn_TurnId",
                table: "PatientReservations",
                column: "TurnId",
                principalTable: "Turn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_VisitTypes_VisitTypeId",
                table: "Reservations",
                column: "VisitTypeId",
                principalTable: "VisitTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turn_Reservations_ReservationId",
                table: "Turn",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
