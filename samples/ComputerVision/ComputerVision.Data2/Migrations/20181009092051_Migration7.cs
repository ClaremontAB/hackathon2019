using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Line_RecognizeText_RecognitionResultId",
                table: "Line");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecognizeText",
                table: "RecognizeText");

            migrationBuilder.RenameTable(
                name: "RecognizeText",
                newName: "RecognitionResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecognitionResult",
                table: "RecognitionResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Line_RecognitionResult_RecognitionResultId",
                table: "Line",
                column: "RecognitionResultId",
                principalTable: "RecognitionResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Line_RecognitionResult_RecognitionResultId",
                table: "Line");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecognitionResult",
                table: "RecognitionResult");

            migrationBuilder.RenameTable(
                name: "RecognitionResult",
                newName: "RecognizeText");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecognizeText",
                table: "RecognizeText",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Line_RecognizeText_RecognitionResultId",
                table: "Line",
                column: "RecognitionResultId",
                principalTable: "RecognizeText",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
