using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CreateDate", "Name", "Note", "Version" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "VJ001", "Go to Tokyo", "1.0" },
                    { 2, new DateTime(2022, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "VJ002", "Go to Osaka", "1.0" },
                    { 3, new DateTime(2022, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "VJ003", "Go to Kyoto", "1.0" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Phone", "RoleName", "Username" },
                values: new object[,]
                {
                    { 1, "Admin@vietjetair.com", "123456", "0123456789", "ADMIN", "Admin" },
                    { 2, "Staff@vietjetair.com", "123456", "0123456789", "GO", "GO Employee" },
                    { 3, "Pilot@vietjetair.com", "123456", "0987654321", "PILOT", "Pilot" },
                    { 4, "Crew@vietjetair.com", "123456", "0987654321", "CREW", "Crew" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
