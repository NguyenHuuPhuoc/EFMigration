using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMigration.Data.Migrations
{
    public partial class InitDbMigrationManually : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicContents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PullDynamicContentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<string>(maxLength: 50, nullable: false),
                    ChannelCode = table.Column<string>(maxLength: 50, nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PullDynamicContentDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PullDynamicContents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HotelId = table.Column<string>(maxLength: 50, nullable: false),
                    RateId = table.Column<string>(maxLength: 50, nullable: false),
                    ChangedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PullDynamicContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaticContents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Status = table.Column<short>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    Type = table.Column<short>(nullable: false),
                    ContentPush = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticContents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicContentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterId = table.Column<long>(nullable: false),
                    RetriedCount = table.Column<short>(nullable: true),
                    LastError = table.Column<string>(nullable: true),
                    Channel = table.Column<string>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicContentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicContentDetails_DynamicContents_MasterId",
                        column: x => x.MasterId,
                        principalTable: "DynamicContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaticContentDetails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterId = table.Column<long>(nullable: false),
                    RetriedCount = table.Column<short>(nullable: true),
                    LastError = table.Column<string>(nullable: true),
                    Channel = table.Column<string>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticContentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticContentDetails_StaticContents_MasterId",
                        column: x => x.MasterId,
                        principalTable: "StaticContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicContentDetails_MasterId",
                table: "DynamicContentDetails",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticContentDetails_MasterId",
                table: "StaticContentDetails",
                column: "MasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicContentDetails");

            migrationBuilder.DropTable(
                name: "PullDynamicContentDetails");

            migrationBuilder.DropTable(
                name: "PullDynamicContents");

            migrationBuilder.DropTable(
                name: "StaticContentDetails");

            migrationBuilder.DropTable(
                name: "DynamicContents");

            migrationBuilder.DropTable(
                name: "StaticContents");
        }
    }
}
