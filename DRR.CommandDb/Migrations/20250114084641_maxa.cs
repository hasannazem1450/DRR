using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRR.CommandDb.Migrations
{
    /// <inheritdoc />
    public partial class maxa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Specialists");

            migrationBuilder.AlterColumn<string>(
                name: "VisitTypeName",
                table: "VisitTypes",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Maxa",
                table: "Specialists",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Insurances",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitTypes_VisitTypeName",
                table: "VisitTypes",
                column: "VisitTypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_Maxa",
                table: "Specialists",
                column: "Maxa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_Name",
                table: "Specialists",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_Name",
                table: "Insurances",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VisitTypes_VisitTypeName",
                table: "VisitTypes");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_Maxa",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_Name",
                table: "Specialists");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_Name",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "Maxa",
                table: "Specialists");

            migrationBuilder.AlterColumn<string>(
                name: "VisitTypeName",
                table: "VisitTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Insurances",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);
        }
    }
}
