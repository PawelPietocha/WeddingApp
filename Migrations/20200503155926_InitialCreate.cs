using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DjCost = table.Column<int>(nullable: false),
                    DjAdvance = table.Column<int>(nullable: false),
                    WeddingHallCost = table.Column<int>(nullable: false),
                    WeddingHallAdvance = table.Column<int>(nullable: false),
                    FlowersCost = table.Column<int>(nullable: false),
                    FlowersAdvance = table.Column<int>(nullable: false),
                    PhotographerCost = table.Column<int>(nullable: false),
                    PhotographerAdvance = table.Column<int>(nullable: false),
                    CameraManCost = table.Column<int>(nullable: false),
                    CameraManAdvance = table.Column<int>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    PlateCost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeddingNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    AccompanyingPerson = table.Column<bool>(nullable: false),
                    Accomodation = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    WeddingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeddingHalls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Location = table.Column<string>(maxLength: 255, nullable: false),
                    NetAdress = table.Column<string>(nullable: true),
                    Quality = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingHalls", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WeddingHalls");
        }
    }
}
