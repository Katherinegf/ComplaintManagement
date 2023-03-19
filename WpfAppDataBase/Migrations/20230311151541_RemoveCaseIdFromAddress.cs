using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppDataBase.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCaseIdFromAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cases_CaseNumber",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CaseNumber",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Cases_AddressId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Addresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "CaseNumber",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaseNumber1",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Comments",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CaseNumber1",
                table: "Comments",
                column: "CaseNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AddressId",
                table: "Cases",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cases_CaseNumber1",
                table: "Comments",
                column: "CaseNumber1",
                principalTable: "Cases",
                principalColumn: "CaseNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cases_CaseNumber1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CaseNumber1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Cases_AddressId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "CaseNumber1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EntryTime",
                table: "Comments",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CaseNumber",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CaseNumber",
                table: "Comments",
                column: "CaseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_AddressId",
                table: "Cases",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cases_CaseNumber",
                table: "Comments",
                column: "CaseNumber",
                principalTable: "Cases",
                principalColumn: "CaseNumber");
        }
    }
}
