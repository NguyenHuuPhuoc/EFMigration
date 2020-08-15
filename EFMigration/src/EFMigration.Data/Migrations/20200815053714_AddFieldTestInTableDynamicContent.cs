using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMigration.Data.Migrations
{
    public partial class AddFieldTestInTableDynamicContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "DynamicContents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "DynamicContents");
        }
    }
}
