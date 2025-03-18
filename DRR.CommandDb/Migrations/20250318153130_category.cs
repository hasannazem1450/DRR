using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DRR.CommandDb.Migrations
{
    /// <inheritdoc />
    public partial class category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialistCategoryId",
                table: "Specialists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpecialistCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialistId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryLogoFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialistCategoryId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorys_SpecialistCategorys_SpecialistCategoryId",
                        column: x => x.SpecialistCategoryId,
                        principalTable: "SpecialistCategorys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_SpecialistCategoryId",
                table: "Specialists",
                column: "SpecialistCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_SpecialistCategoryId",
                table: "Categorys",
                column: "SpecialistCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialists_SpecialistCategorys_SpecialistCategoryId",
                table: "Specialists",
                column: "SpecialistCategoryId",
                principalTable: "SpecialistCategorys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialists_SpecialistCategorys_SpecialistCategoryId",
                table: "Specialists");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "SpecialistCategorys");

            migrationBuilder.DropIndex(
                name: "IX_Specialists_SpecialistCategoryId",
                table: "Specialists");

            migrationBuilder.DropColumn(
                name: "SpecialistCategoryId",
                table: "Specialists");
        }
    }
}
