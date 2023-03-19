using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppDataBase.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCaseNumberFromComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cases_CaseNumber1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CaseNumber1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CaseNumber1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "CaseNumber",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CaseNumber",
                table: "Comments",
                column: "CaseNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cases_CaseNumber",
                table: "Comments",
                column: "CaseNumber",
                principalTable: "Cases",
                principalColumn: "CaseNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Cases_CaseNumber",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CaseNumber",
                table: "Comments");

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CaseNumber1",
                table: "Comments",
                column: "CaseNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Cases_CaseNumber1",
                table: "Comments",
                column: "CaseNumber1",
                principalTable: "Cases",
                principalColumn: "CaseNumber");
        }
    }
}
