using Microsoft.EntityFrameworkCore.Migrations;

namespace EFMigration.Data.Migrations
{
    public partial class AddFieldNameInDynamicContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DynamicContents",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "DynamicContents");
        }
    }
}
