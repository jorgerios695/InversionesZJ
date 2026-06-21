using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InversionesZJ.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUpdatedAtColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "SEC",
                table: "Users",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "SEC",
                table: "Roles",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "CLI",
                table: "Responsibles",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "OPE",
                table: "Payments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "SEC",
                table: "PasswordResetTokens",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "PAR",
                table: "LoanTypes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "OPE",
                table: "Loans",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "PAR",
                table: "GeneralParameters",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "OPE",
                table: "Delinquencies",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "ÚpdatedAt",
                schema: "CLI",
                table: "Clients",
                newName: "UpdatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "SEC",
                table: "Users",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "SEC",
                table: "Roles",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "CLI",
                table: "Responsibles",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "OPE",
                table: "Payments",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "SEC",
                table: "PasswordResetTokens",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "PAR",
                table: "LoanTypes",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "OPE",
                table: "Loans",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "PAR",
                table: "GeneralParameters",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "OPE",
                table: "Delinquencies",
                newName: "ÚpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                schema: "CLI",
                table: "Clients",
                newName: "ÚpdatedAt");
        }
    }
}
