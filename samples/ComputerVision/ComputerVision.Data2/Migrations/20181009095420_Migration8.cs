using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RecognitionResultId",
                table: "ImageFile",
                newName: "PrintedRecognitionResultId");

            migrationBuilder.AddColumn<int>(
                name: "HandwrittenRecognitionResultId",
                table: "ImageFile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HandwrittenRecognitionResultId",
                table: "ImageFile");

            migrationBuilder.RenameColumn(
                name: "PrintedRecognitionResultId",
                table: "ImageFile",
                newName: "RecognitionResultId");
        }
    }
}
