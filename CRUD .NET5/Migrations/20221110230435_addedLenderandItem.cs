using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_.NET5.Migrations
{
    public partial class addedLenderandItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lender",
                table: "items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "items");

            migrationBuilder.DropColumn(
                name: "Lender",
                table: "items");
        }
    }
}
