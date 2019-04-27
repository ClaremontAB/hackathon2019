using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnylysisId",
                table: "ImageFile",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnylysisId",
                table: "ImageFile");
        }
    }
}
