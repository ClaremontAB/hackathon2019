using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageBytes");

            migrationBuilder.AddColumn<string>(
                name: "ImageSasToken",
                table: "ImageFile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUri",
                table: "ImageFile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUriWithSasToken",
                table: "ImageFile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSasToken",
                table: "ImageFile");

            migrationBuilder.DropColumn(
                name: "ImageUri",
                table: "ImageFile");

            migrationBuilder.DropColumn(
                name: "ImageUriWithSasToken",
                table: "ImageFile");

            migrationBuilder.CreateTable(
                name: "ImageBytes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bytes = table.Column<byte[]>(nullable: true),
                    ImageFileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageBytes", x => x.Id);
                });
        }
    }
}
