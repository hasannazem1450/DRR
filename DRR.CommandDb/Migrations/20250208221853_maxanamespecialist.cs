using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRR.CommandDb.Migrations
{
    /// <inheritdoc />
    public partial class maxanamespecialist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaxaName",
                table: "Specialists",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxaName",
                table: "Specialists");
        }
    }
}
