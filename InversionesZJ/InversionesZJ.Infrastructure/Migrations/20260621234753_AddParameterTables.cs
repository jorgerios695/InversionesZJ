using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InversionesZJ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddParameterTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GeneralParameters_Key",
                schema: "PAR",
                table: "GeneralParameters");

            migrationBuilder.DropColumn(
                name: "Key",
                schema: "PAR",
                table: "GeneralParameters");

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "PAR",
                table: "GeneralParameters");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "PAR",
                table: "GeneralParameters",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "PAR",
                table: "GeneralParameters",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "DetailParameters",
                schema: "PAR",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralParameterId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailParameters_GeneralParameters_GeneralParameterId",
                        column: x => x.GeneralParameterId,
                        principalSchema: "PAR",
                        principalTable: "GeneralParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralParameters_Code",
                schema: "PAR",
                table: "GeneralParameters",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailParameters_GeneralParameterId",
                schema: "PAR",
                table: "DetailParameters",
                column: "GeneralParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailParameters",
                schema: "PAR");

            migrationBuilder.DropIndex(
                name: "IX_GeneralParameters_Code",
                schema: "PAR",
                table: "GeneralParameters");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "PAR",
                table: "GeneralParameters");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "PAR",
                table: "GeneralParameters");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "PAR",
                table: "GeneralParameters",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                schema: "PAR",
                table: "GeneralParameters",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralParameters_Key",
                schema: "PAR",
                table: "GeneralParameters",
                column: "Key",
                unique: true);
        }
    }
}
