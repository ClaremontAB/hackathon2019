using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HashString = table.Column<string>(nullable: true),
                    CameraManufacturer = table.Column<string>(nullable: true),
                    CameraModel = table.Column<string>(nullable: true),
                    DateTaken = table.Column<DateTimeOffset>(nullable: false),
                    Height = table.Column<long>(nullable: false),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Rating = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Width = table.Column<long>(nullable: false),
                    ContentType = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    DisplayType = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    FolderRelativeId = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageFile");
        }
    }
}
