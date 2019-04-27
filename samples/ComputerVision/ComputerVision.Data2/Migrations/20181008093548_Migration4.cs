using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorInfoDominantColor");

            migrationBuilder.DropTable(
                name: "ImageDescriptionDetailsTag");

            migrationBuilder.AddColumn<string>(
                name: "Orientation",
                table: "ImageFile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "ImageDescriptionDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DominantColors",
                table: "ColorInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Orientation",
                table: "ImageFile");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "ImageDescriptionDetails");

            migrationBuilder.DropColumn(
                name: "DominantColors",
                table: "ColorInfo");

            migrationBuilder.CreateTable(
                name: "ColorInfoDominantColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<string>(nullable: true),
                    ColorInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorInfoDominantColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorInfoDominantColor_ColorInfo_ColorInfoId",
                        column: x => x.ColorInfoId,
                        principalTable: "ColorInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageDescriptionDetailsTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageDescriptionDetailsId = table.Column<int>(nullable: true),
                    Tag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDescriptionDetailsTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageDescriptionDetailsTag_ImageDescriptionDetails_ImageDescriptionDetailsId",
                        column: x => x.ImageDescriptionDetailsId,
                        principalTable: "ImageDescriptionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorInfoDominantColor_ColorInfoId",
                table: "ColorInfoDominantColor",
                column: "ColorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDescriptionDetailsTag_ImageDescriptionDetailsId",
                table: "ImageDescriptionDetailsTag",
                column: "ImageDescriptionDetailsId");
        }
    }
}
