using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRR.CommandDb.Migrations
{
    /// <inheritdoc />
    public partial class reservchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReservations_Reservations_ReservationId",
                table: "PatientReservations");

            migrationBuilder.DropIndex(
                name: "IX_PatientReservations_ReservationId",
                table: "PatientReservations");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Turn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalTurnCount",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Turn_ReservationId",
                table: "Turn",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turn_Reservations_ReservationId",
                table: "Turn",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turn_Reservations_ReservationId",
                table: "Turn");

            migrationBuilder.DropIndex(
                name: "IX_Turn_ReservationId",
                table: "Turn");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Turn");

            migrationBuilder.DropColumn(
                name: "TotalTurnCount",
                table: "Reservations");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReservations_ReservationId",
                table: "PatientReservations",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReservations_Reservations_ReservationId",
                table: "PatientReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
