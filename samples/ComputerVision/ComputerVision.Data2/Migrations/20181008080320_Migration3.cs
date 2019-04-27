using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnylysisId",
                table: "ImageFile",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AnylysisId",
                table: "ImageFile",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
