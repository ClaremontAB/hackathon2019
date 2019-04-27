using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerVision.Data2.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlurLevel = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    X = table.Column<double>(nullable: false),
                    Y = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anger = table.Column<double>(nullable: false),
                    Contempt = table.Column<double>(nullable: false),
                    Disgust = table.Column<double>(nullable: false),
                    Fear = table.Column<double>(nullable: false),
                    Happiness = table.Column<double>(nullable: false),
                    Neutral = table.Column<double>(nullable: false),
                    Sadness = table.Column<double>(nullable: false),
                    Surprise = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exposure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExposureLevel = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exposure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacialHair",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Moustache = table.Column<double>(nullable: false),
                    Beard = table.Column<double>(nullable: false),
                    Sideburns = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacialHair", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hair",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bald = table.Column<double>(nullable: false),
                    Invisible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hair", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadPose",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Roll = table.Column<double>(nullable: false),
                    Yaw = table.Column<double>(nullable: false),
                    Pitch = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadPose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makeup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EyeMakeup = table.Column<bool>(nullable: false),
                    LipMakeup = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makeup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoiseLevel = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Occlusion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ForeheadOccluded = table.Column<bool>(nullable: false),
                    EyeOccluded = table.Column<bool>(nullable: false),
                    MouthOccluded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occlusion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaceLandmarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UpperLipBottomId = table.Column<int>(nullable: true),
                    UpperLipTopId = table.Column<int>(nullable: true),
                    NoseRightAlarOutTipId = table.Column<int>(nullable: true),
                    NoseLeftAlarOutTipId = table.Column<int>(nullable: true),
                    NoseRightAlarTopId = table.Column<int>(nullable: true),
                    NoseLeftAlarTopId = table.Column<int>(nullable: true),
                    NoseRootRightId = table.Column<int>(nullable: true),
                    NoseRootLeftId = table.Column<int>(nullable: true),
                    EyeRightOuterId = table.Column<int>(nullable: true),
                    EyeRightBottomId = table.Column<int>(nullable: true),
                    EyeRightTopId = table.Column<int>(nullable: true),
                    EyeRightInnerId = table.Column<int>(nullable: true),
                    EyebrowRightOuterId = table.Column<int>(nullable: true),
                    EyebrowRightInnerId = table.Column<int>(nullable: true),
                    EyeLeftInnerId = table.Column<int>(nullable: true),
                    EyeLeftBottomId = table.Column<int>(nullable: true),
                    EyeLeftTopId = table.Column<int>(nullable: true),
                    EyeLeftOuterId = table.Column<int>(nullable: true),
                    EyebrowLeftInnerId = table.Column<int>(nullable: true),
                    EyebrowLeftOuterId = table.Column<int>(nullable: true),
                    MouthRightId = table.Column<int>(nullable: true),
                    MouthLeftId = table.Column<int>(nullable: true),
                    NoseTipId = table.Column<int>(nullable: true),
                    PupilRightId = table.Column<int>(nullable: true),
                    PupilLeftId = table.Column<int>(nullable: true),
                    UnderLipTopId = table.Column<int>(nullable: true),
                    UnderLipBottomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceLandmarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeLeftBottomId",
                        column: x => x.EyeLeftBottomId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeLeftInnerId",
                        column: x => x.EyeLeftInnerId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeLeftOuterId",
                        column: x => x.EyeLeftOuterId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeLeftTopId",
                        column: x => x.EyeLeftTopId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeRightBottomId",
                        column: x => x.EyeRightBottomId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeRightInnerId",
                        column: x => x.EyeRightInnerId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeRightOuterId",
                        column: x => x.EyeRightOuterId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyeRightTopId",
                        column: x => x.EyeRightTopId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyebrowLeftInnerId",
                        column: x => x.EyebrowLeftInnerId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyebrowLeftOuterId",
                        column: x => x.EyebrowLeftOuterId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyebrowRightInnerId",
                        column: x => x.EyebrowRightInnerId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_EyebrowRightOuterId",
                        column: x => x.EyebrowRightOuterId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_MouthLeftId",
                        column: x => x.MouthLeftId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_MouthRightId",
                        column: x => x.MouthRightId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_NoseLeftAlarOutTipId",
                        column: x => x.NoseLeftAlarOutTipId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_NoseLeftAlarTopId",
                        column: x => x.NoseLeftAlarTopId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_NoseRightAlarOutTipId",
                        column: x => x.NoseRightAlarOutTipId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_NoseRightAlarTopId",
                        column: x => x.NoseRightAlarTopId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_NoseRootLeftId",
                        column: x => x.NoseRootLeftId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_NoseRootRightId",
                        column: x => x.NoseRootRightId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_NoseTipId",
                        column: x => x.NoseTipId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_PupilLeftId",
                        column: x => x.PupilLeftId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_PupilRightId",
                        column: x => x.PupilRightId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_UnderLipBottomId",
                        column: x => x.UnderLipBottomId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_UnderLipTopId",
                        column: x => x.UnderLipTopId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_UpperLipBottomId",
                        column: x => x.UpperLipBottomId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceLandmarks_Coordinate_UpperLipTopId",
                        column: x => x.UpperLipTopId,
                        principalTable: "Coordinate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairColor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Color = table.Column<int>(nullable: false),
                    Confidence = table.Column<double>(nullable: false),
                    HairId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HairColor_Hair_HairId",
                        column: x => x.HairId,
                        principalTable: "Hair",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FaceAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<double>(nullable: true),
                    Gender = table.Column<int>(nullable: true),
                    Smile = table.Column<double>(nullable: true),
                    FacialHairId = table.Column<int>(nullable: true),
                    Glasses = table.Column<int>(nullable: true),
                    HeadPoseId = table.Column<int>(nullable: true),
                    EmotionId = table.Column<int>(nullable: true),
                    HairId = table.Column<int>(nullable: true),
                    MakeupId = table.Column<int>(nullable: true),
                    OcclusionId = table.Column<int>(nullable: true),
                    BlurId = table.Column<int>(nullable: true),
                    ExposureId = table.Column<int>(nullable: true),
                    NoiseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaceAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_Blur_BlurId",
                        column: x => x.BlurId,
                        principalTable: "Blur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_Emotion_EmotionId",
                        column: x => x.EmotionId,
                        principalTable: "Emotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_Exposure_ExposureId",
                        column: x => x.ExposureId,
                        principalTable: "Exposure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_FacialHair_FacialHairId",
                        column: x => x.FacialHairId,
                        principalTable: "FacialHair",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_Hair_HairId",
                        column: x => x.HairId,
                        principalTable: "Hair",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_HeadPose_HeadPoseId",
                        column: x => x.HeadPoseId,
                        principalTable: "HeadPose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_Makeup_MakeupId",
                        column: x => x.MakeupId,
                        principalTable: "Makeup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_Noise_NoiseId",
                        column: x => x.NoiseId,
                        principalTable: "Noise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FaceAttributes_Occlusion_OcclusionId",
                        column: x => x.OcclusionId,
                        principalTable: "Occlusion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accessory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Confidence = table.Column<double>(nullable: false),
                    FaceAttributesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accessory_FaceAttributes_FaceAttributesId",
                        column: x => x.FaceAttributesId,
                        principalTable: "FaceAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetectedFace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageFileId = table.Column<int>(nullable: false),
                    FaceId = table.Column<Guid>(nullable: true),
                    FaceRectangleId = table.Column<int>(nullable: true),
                    FaceLandmarksId = table.Column<int>(nullable: true),
                    FaceAttributesId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetectedFace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetectedFace_FaceAttributes_FaceAttributesId",
                        column: x => x.FaceAttributesId,
                        principalTable: "FaceAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetectedFace_FaceLandmarks_FaceLandmarksId",
                        column: x => x.FaceLandmarksId,
                        principalTable: "FaceLandmarks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetectedFace_FaceRectangle_FaceRectangleId",
                        column: x => x.FaceRectangleId,
                        principalTable: "FaceRectangle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessory_FaceAttributesId",
                table: "Accessory",
                column: "FaceAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedFace_FaceAttributesId",
                table: "DetectedFace",
                column: "FaceAttributesId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedFace_FaceLandmarksId",
                table: "DetectedFace",
                column: "FaceLandmarksId");

            migrationBuilder.CreateIndex(
                name: "IX_DetectedFace_FaceRectangleId",
                table: "DetectedFace",
                column: "FaceRectangleId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_BlurId",
                table: "FaceAttributes",
                column: "BlurId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_EmotionId",
                table: "FaceAttributes",
                column: "EmotionId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_ExposureId",
                table: "FaceAttributes",
                column: "ExposureId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_FacialHairId",
                table: "FaceAttributes",
                column: "FacialHairId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_HairId",
                table: "FaceAttributes",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_HeadPoseId",
                table: "FaceAttributes",
                column: "HeadPoseId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_MakeupId",
                table: "FaceAttributes",
                column: "MakeupId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_NoiseId",
                table: "FaceAttributes",
                column: "NoiseId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceAttributes_OcclusionId",
                table: "FaceAttributes",
                column: "OcclusionId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeLeftBottomId",
                table: "FaceLandmarks",
                column: "EyeLeftBottomId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeLeftInnerId",
                table: "FaceLandmarks",
                column: "EyeLeftInnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeLeftOuterId",
                table: "FaceLandmarks",
                column: "EyeLeftOuterId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeLeftTopId",
                table: "FaceLandmarks",
                column: "EyeLeftTopId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeRightBottomId",
                table: "FaceLandmarks",
                column: "EyeRightBottomId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeRightInnerId",
                table: "FaceLandmarks",
                column: "EyeRightInnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeRightOuterId",
                table: "FaceLandmarks",
                column: "EyeRightOuterId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyeRightTopId",
                table: "FaceLandmarks",
                column: "EyeRightTopId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyebrowLeftInnerId",
                table: "FaceLandmarks",
                column: "EyebrowLeftInnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyebrowLeftOuterId",
                table: "FaceLandmarks",
                column: "EyebrowLeftOuterId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyebrowRightInnerId",
                table: "FaceLandmarks",
                column: "EyebrowRightInnerId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_EyebrowRightOuterId",
                table: "FaceLandmarks",
                column: "EyebrowRightOuterId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_MouthLeftId",
                table: "FaceLandmarks",
                column: "MouthLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_MouthRightId",
                table: "FaceLandmarks",
                column: "MouthRightId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_NoseLeftAlarOutTipId",
                table: "FaceLandmarks",
                column: "NoseLeftAlarOutTipId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_NoseLeftAlarTopId",
                table: "FaceLandmarks",
                column: "NoseLeftAlarTopId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_NoseRightAlarOutTipId",
                table: "FaceLandmarks",
                column: "NoseRightAlarOutTipId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_NoseRightAlarTopId",
                table: "FaceLandmarks",
                column: "NoseRightAlarTopId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_NoseRootLeftId",
                table: "FaceLandmarks",
                column: "NoseRootLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_NoseRootRightId",
                table: "FaceLandmarks",
                column: "NoseRootRightId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_NoseTipId",
                table: "FaceLandmarks",
                column: "NoseTipId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_PupilLeftId",
                table: "FaceLandmarks",
                column: "PupilLeftId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_PupilRightId",
                table: "FaceLandmarks",
                column: "PupilRightId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_UnderLipBottomId",
                table: "FaceLandmarks",
                column: "UnderLipBottomId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_UnderLipTopId",
                table: "FaceLandmarks",
                column: "UnderLipTopId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_UpperLipBottomId",
                table: "FaceLandmarks",
                column: "UpperLipBottomId");

            migrationBuilder.CreateIndex(
                name: "IX_FaceLandmarks_UpperLipTopId",
                table: "FaceLandmarks",
                column: "UpperLipTopId");

            migrationBuilder.CreateIndex(
                name: "IX_HairColor_HairId",
                table: "HairColor",
                column: "HairId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessory");

            migrationBuilder.DropTable(
                name: "DetectedFace");

            migrationBuilder.DropTable(
                name: "HairColor");

            migrationBuilder.DropTable(
                name: "FaceAttributes");

            migrationBuilder.DropTable(
                name: "FaceLandmarks");

            migrationBuilder.DropTable(
                name: "Blur");

            migrationBuilder.DropTable(
                name: "Emotion");

            migrationBuilder.DropTable(
                name: "Exposure");

            migrationBuilder.DropTable(
                name: "FacialHair");

            migrationBuilder.DropTable(
                name: "Hair");

            migrationBuilder.DropTable(
                name: "HeadPose");

            migrationBuilder.DropTable(
                name: "Makeup");

            migrationBuilder.DropTable(
                name: "Noise");

            migrationBuilder.DropTable(
                name: "Occlusion");

            migrationBuilder.DropTable(
                name: "Coordinate");
        }
    }
}
