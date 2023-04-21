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
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationFrom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    VerificationOTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VerifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordResetOTP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetOTPExpires = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightID = table.Column<int>(type: "int", nullable: false),
                    Document_TypeID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    GroupID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_Document_TypeID",
                        column: x => x.Document_TypeID,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Flights_FlightID",
                        column: x => x.FlightID,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentFiles_Documents_DocumentID",
                        column: x => x.DocumentID,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentFiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "CreateDate", "Note", "Type_Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some note", "Load Summary" },
                    { 2, new DateTime(2021, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Some note for update", "Update Summary" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "DepartureDate", "FlightCode", "LocationFrom", "LocationTo" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "VJ001", "Ha Noi", "Ho Chi Minh" },
                    { 2, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VJ002", "Ho Chi Minh", "Con Dao" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "CreateDate", "GroupName", "Note" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pilot", "Some note for pilot" },
                    { 2, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stewardess", "Some notification for crew" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Staff" },
                    { 3, "Pilot" },
                    { 4, "Stewardess" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordResetOTP", "PasswordSalt", "Phone", "ResetOTPExpires", "RoleID", "Username", "VerificationOTP", "VerifiedAt" },
                values: new object[,]
                {
                    { 1, "Admin@vietjetair.com", new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, null, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 }, "098765421", null, 1, "Admin", "773198", new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Staff@vietjetair.com", new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, null, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 }, "098765421", null, 2, "GO Employee", "538203", new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Pilot@vietjetair.com", new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, null, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 }, "098765421", null, 3, "Pilot", "345453", new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Stewardess@vietjetair.com", new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, null, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 }, "098765421", null, 4, "Stewardess", "773358", new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "CreateDate", "Document_TypeID", "FlightID", "GroupID", "Name", "Note", "Url", "UserID", "Version" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1, "Document 1", "Some note", "~/files/News.xlsx", 1, "1.0" },
                    { 2, new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, "Document 2", "Update note", "~/files/Characters.xlsx", 2, "1.1" },
                    { 3, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, "Time line of Fight trip", "Some note", "~/files/Users.xlsx", 2, "1.0" }
                });

            migrationBuilder.InsertData(
                table: "DocumentFiles",
                columns: new[] { "Id", "CreateDate", "DocumentID", "FileName", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ganyu Picture", "~/files/Ganyu-1st prize.jpg", null },
                    { 2, new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fresher DOCX", "~/files/Fresher-.NET.docx", null },
                    { 3, new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Mac Le Nin", "~/files/NỘI DUNG ÔN TẬP TRIẾT HỌC MLN.docx", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFiles_DocumentID",
                table: "DocumentFiles",
                column: "DocumentID");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentFiles_UserId",
                table: "DocumentFiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Document_TypeID",
                table: "Documents",
                column: "Document_TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_FlightID",
                table: "Documents",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_GroupID",
                table: "Documents",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_UserID",
                table: "Documents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentFiles");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
