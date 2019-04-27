using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdultInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsAdultContent = table.Column<bool>(nullable: false),
                    IsRacyContent = table.Column<bool>(nullable: false),
                    AdultScore = table.Column<double>(nullable: false),
                    RacyScore = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DominantColorForeground = table.Column<string>(nullable: true),
                    DominantColorBackground = table.Column<string>(nullable: true),
                    AccentColor = table.Column<string>(nullable: true),
                    IsBWImg = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaceRectangle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Left = table.Column<int>(nullable: false),
                    Top = table.Column<int>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceRectangle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageDescriptionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageDescriptionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageMetadata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Width = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Format = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageMetadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClipArtType = table.Column<int>(nullable: false),
                    LineDrawingType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LandmarksModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    CategoryDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandmarksModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandmarksModel_CategoryDetail_CategoryDetailId",
                        column: x => x.CategoryDetailId,
                        principalTable: "CategoryDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "CelebritiesModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    FaceRectangleId = table.Column<int>(nullable: true),
                    CategoryDetailId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelebritiesModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CelebritiesModel_CategoryDetail_CategoryDetailId",
                        column: x => x.CategoryDetailId,
                        principalTable: "CategoryDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CelebritiesModel_FaceRectangle_FaceRectangleId",
                        column: x => x.FaceRectangleId,
                        principalTable: "FaceRectangle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageCaption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    ImageDescriptionDetailsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageCaption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageCaption_ImageDescriptionDetails_ImageDescriptionDetailsId",
                        column: x => x.ImageDescriptionDetailsId,
                        principalTable: "ImageDescriptionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageDescriptionDetailsTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tag = table.Column<string>(nullable: true),
                    ImageDescriptionDetailsId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "ImageAnalysis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdultId = table.Column<int>(nullable: true),
                    ColorId = table.Column<int>(nullable: true),
                    ImageTypeId = table.Column<int>(nullable: true),
                    DescriptionId = table.Column<int>(nullable: true),
                    RequestId = table.Column<string>(nullable: true),
                    MetadataId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageAnalysis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageAnalysis_AdultInfo_AdultId",
                        column: x => x.AdultId,
                        principalTable: "AdultInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageAnalysis_ColorInfo_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ColorInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageAnalysis_ImageDescriptionDetails_DescriptionId",
                        column: x => x.DescriptionId,
                        principalTable: "ImageDescriptionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageAnalysis_ImageType_ImageTypeId",
                        column: x => x.ImageTypeId,
                        principalTable: "ImageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageAnalysis_ImageMetadata_MetadataId",
                        column: x => x.MetadataId,
                        principalTable: "ImageMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Score = table.Column<double>(nullable: false),
                    DetailId = table.Column<int>(nullable: true),
                    ImageAnalysisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_CategoryDetail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "CategoryDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_ImageAnalysis_ImageAnalysisId",
                        column: x => x.ImageAnalysisId,
                        principalTable: "ImageAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaceDescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: true),
                    FaceRectangleId = table.Column<int>(nullable: true),
                    ImageAnalysisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceDescription_FaceRectangle_FaceRectangleId",
                        column: x => x.FaceRectangleId,
                        principalTable: "FaceRectangle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceDescription_ImageAnalysis_ImageAnalysisId",
                        column: x => x.ImageAnalysisId,
                        principalTable: "ImageAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Confidence = table.Column<double>(nullable: false),
                    Hint = table.Column<string>(nullable: true),
                    ImageAnalysisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageTag_ImageAnalysis_ImageAnalysisId",
                        column: x => x.ImageAnalysisId,
                        principalTable: "ImageAnalysis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_DetailId",
                table: "Category",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ImageAnalysisId",
                table: "Category",
                column: "ImageAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebritiesModel_CategoryDetailId",
                table: "CelebritiesModel",
                column: "CategoryDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CelebritiesModel_FaceRectangleId",
                table: "CelebritiesModel",
                column: "FaceRectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorInfoDominantColor_ColorInfoId",
                table: "ColorInfoDominantColor",
                column: "ColorInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceDescription_FaceRectangleId",
                table: "FaceDescription",
                column: "FaceRectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceDescription_ImageAnalysisId",
                table: "FaceDescription",
                column: "ImageAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAnalysis_AdultId",
                table: "ImageAnalysis",
                column: "AdultId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAnalysis_ColorId",
                table: "ImageAnalysis",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAnalysis_DescriptionId",
                table: "ImageAnalysis",
                column: "DescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAnalysis_ImageTypeId",
                table: "ImageAnalysis",
                column: "ImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageAnalysis_MetadataId",
                table: "ImageAnalysis",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageCaption_ImageDescriptionDetailsId",
                table: "ImageCaption",
                column: "ImageDescriptionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageDescriptionDetailsTag_ImageDescriptionDetailsId",
                table: "ImageDescriptionDetailsTag",
                column: "ImageDescriptionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageTag_ImageAnalysisId",
                table: "ImageTag",
                column: "ImageAnalysisId");

            migrationBuilder.CreateIndex(
                name: "IX_LandmarksModel_CategoryDetailId",
                table: "LandmarksModel",
                column: "CategoryDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CelebritiesModel");

            migrationBuilder.DropTable(
                name: "ColorInfoDominantColor");

            migrationBuilder.DropTable(
                name: "FaceDescription");

            migrationBuilder.DropTable(
                name: "ImageCaption");

            migrationBuilder.DropTable(
                name: "ImageDescriptionDetailsTag");

            migrationBuilder.DropTable(
                name: "ImageTag");

            migrationBuilder.DropTable(
                name: "LandmarksModel");

            migrationBuilder.DropTable(
                name: "FaceRectangle");

            migrationBuilder.DropTable(
                name: "ImageAnalysis");

            migrationBuilder.DropTable(
                name: "CategoryDetail");

            migrationBuilder.DropTable(
                name: "AdultInfo");

            migrationBuilder.DropTable(
                name: "ColorInfo");

            migrationBuilder.DropTable(
                name: "ImageDescriptionDetails");

            migrationBuilder.DropTable(
                name: "ImageType");

            migrationBuilder.DropTable(
                name: "ImageMetadata");
        }
    }
}
