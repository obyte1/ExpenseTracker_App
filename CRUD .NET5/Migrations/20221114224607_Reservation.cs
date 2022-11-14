using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD_.NET5.Migrations
{
    public partial class Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reservationModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArrivalDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberOfPeople = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservationModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reservationModel");
        }
    }
}
