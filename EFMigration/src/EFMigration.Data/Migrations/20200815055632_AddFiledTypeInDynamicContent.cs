using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMigration.Data.Migrations
{
    public partial class AddFiledTypeInDynamicContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Test",
                table: "DynamicContents",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "DynamicContents",
                newName: "Test");
        }
    }
}
