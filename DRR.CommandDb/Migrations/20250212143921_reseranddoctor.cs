using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRR.CommandDb.Migrations
{
    /// <inheritdoc />
    public partial class reseranddoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReservationDate",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Doctors",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Doctors");

            migrationBuilder.AlterColumn<string>(
                name: "ReservationDate",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
