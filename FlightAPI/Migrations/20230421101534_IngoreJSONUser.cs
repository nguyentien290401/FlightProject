﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightAPI.Migrations
{
    /// <inheritdoc />
    public partial class IngoreJSONUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 246, 33, 127, 139, 34, 75, 106, 104, 157, 246, 188, 2, 44, 208, 28, 160, 116, 207, 198, 175, 48, 170, 179, 134, 77, 225, 151, 41, 151, 132, 141, 36, 0, 181, 220, 51, 18, 48, 60, 176, 126, 200, 24, 53, 145, 158, 138, 127, 22, 98, 84, 245, 186, 82, 158, 51, 148, 246, 119, 4, 205, 12, 180, 68 }, new byte[] { 91, 174, 207, 44, 202, 128, 115, 7, 103, 12, 38, 65, 11, 165, 249, 35, 157, 189, 88, 201, 37, 54, 251, 1, 220, 145, 35, 232, 173, 167, 7, 165, 48, 152, 132, 231, 200, 181, 217, 214, 252, 109, 201, 247, 235, 102, 125, 254, 143, 66, 211, 52, 244, 155, 72, 4, 103, 144, 157, 253, 14, 181, 40, 43, 100, 149, 81, 201, 72, 73, 227, 33, 106, 195, 232, 176, 92, 124, 44, 21, 178, 34, 32, 75, 68, 6, 102, 12, 231, 44, 68, 70, 123, 20, 125, 27, 221, 111, 225, 204, 43, 32, 96, 90, 187, 98, 235, 111, 61, 55, 77, 138, 161, 250, 121, 93, 9, 200, 246, 69, 142, 138, 49, 201, 164, 65, 235, 68 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 246, 33, 127, 139, 34, 75, 106, 104, 157, 246, 188, 2, 44, 208, 28, 160, 116, 207, 198, 175, 48, 170, 179, 134, 77, 225, 151, 41, 151, 132, 141, 36, 0, 181, 220, 51, 18, 48, 60, 176, 126, 200, 24, 53, 145, 158, 138, 127, 22, 98, 84, 245, 186, 82, 158, 51, 148, 246, 119, 4, 205, 12, 180, 68 }, new byte[] { 91, 174, 207, 44, 202, 128, 115, 7, 103, 12, 38, 65, 11, 165, 249, 35, 157, 189, 88, 201, 37, 54, 251, 1, 220, 145, 35, 232, 173, 167, 7, 165, 48, 152, 132, 231, 200, 181, 217, 214, 252, 109, 201, 247, 235, 102, 125, 254, 143, 66, 211, 52, 244, 155, 72, 4, 103, 144, 157, 253, 14, 181, 40, 43, 100, 149, 81, 201, 72, 73, 227, 33, 106, 195, 232, 176, 92, 124, 44, 21, 178, 34, 32, 75, 68, 6, 102, 12, 231, 44, 68, 70, 123, 20, 125, 27, 221, 111, 225, 204, 43, 32, 96, 90, 187, 98, 235, 111, 61, 55, 77, 138, 161, 250, 121, 93, 9, 200, 246, 69, 142, 138, 49, 201, 164, 65, 235, 68 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 246, 33, 127, 139, 34, 75, 106, 104, 157, 246, 188, 2, 44, 208, 28, 160, 116, 207, 198, 175, 48, 170, 179, 134, 77, 225, 151, 41, 151, 132, 141, 36, 0, 181, 220, 51, 18, 48, 60, 176, 126, 200, 24, 53, 145, 158, 138, 127, 22, 98, 84, 245, 186, 82, 158, 51, 148, 246, 119, 4, 205, 12, 180, 68 }, new byte[] { 91, 174, 207, 44, 202, 128, 115, 7, 103, 12, 38, 65, 11, 165, 249, 35, 157, 189, 88, 201, 37, 54, 251, 1, 220, 145, 35, 232, 173, 167, 7, 165, 48, 152, 132, 231, 200, 181, 217, 214, 252, 109, 201, 247, 235, 102, 125, 254, 143, 66, 211, 52, 244, 155, 72, 4, 103, 144, 157, 253, 14, 181, 40, 43, 100, 149, 81, 201, 72, 73, 227, 33, 106, 195, 232, 176, 92, 124, 44, 21, 178, 34, 32, 75, 68, 6, 102, 12, 231, 44, 68, 70, 123, 20, 125, 27, 221, 111, 225, 204, 43, 32, 96, 90, 187, 98, 235, 111, 61, 55, 77, 138, 161, 250, 121, 93, 9, 200, 246, 69, 142, 138, 49, 201, 164, 65, 235, 68 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 246, 33, 127, 139, 34, 75, 106, 104, 157, 246, 188, 2, 44, 208, 28, 160, 116, 207, 198, 175, 48, 170, 179, 134, 77, 225, 151, 41, 151, 132, 141, 36, 0, 181, 220, 51, 18, 48, 60, 176, 126, 200, 24, 53, 145, 158, 138, 127, 22, 98, 84, 245, 186, 82, 158, 51, 148, 246, 119, 4, 205, 12, 180, 68 }, new byte[] { 91, 174, 207, 44, 202, 128, 115, 7, 103, 12, 38, 65, 11, 165, 249, 35, 157, 189, 88, 201, 37, 54, 251, 1, 220, 145, 35, 232, 173, 167, 7, 165, 48, 152, 132, 231, 200, 181, 217, 214, 252, 109, 201, 247, 235, 102, 125, 254, 143, 66, 211, 52, 244, 155, 72, 4, 103, 144, 157, 253, 14, 181, 40, 43, 100, 149, 81, 201, 72, 73, 227, 33, 106, 195, 232, 176, 92, 124, 44, 21, 178, 34, 32, 75, 68, 6, 102, 12, 231, 44, 68, 70, 123, 20, 125, 27, 221, 111, 225, 204, 43, 32, 96, 90, 187, 98, 235, 111, 61, 55, 77, 138, 161, 250, 121, 93, 9, 200, 246, 69, 142, 138, 49, 201, 164, 65, 235, 68 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 63, 177, 90, 134, 198, 49, 58, 190, 201, 249, 31, 83, 55, 102, 179, 7, 105, 199, 240, 58, 231, 120, 167, 128, 255, 62, 224, 78, 200, 86, 214, 167, 1, 248, 251, 161, 156, 130, 123, 206, 114, 232, 161, 58, 251, 177, 192, 82, 246, 245, 109, 209, 44, 67, 33, 36, 10, 83, 227, 198, 159, 34, 16, 109 }, new byte[] { 20, 22, 208, 176, 35, 217, 107, 65, 37, 9, 203, 28, 98, 181, 158, 179, 101, 96, 193, 249, 22, 28, 115, 127, 181, 70, 143, 208, 170, 11, 103, 140, 77, 148, 124, 153, 38, 233, 130, 253, 73, 86, 218, 30, 134, 37, 55, 212, 140, 229, 251, 55, 147, 95, 25, 167, 177, 98, 87, 31, 230, 44, 124, 91, 133, 34, 198, 218, 111, 89, 56, 52, 253, 160, 138, 76, 103, 130, 90, 137, 74, 210, 222, 177, 232, 218, 29, 73, 14, 188, 105, 188, 155, 226, 231, 77, 213, 138, 180, 235, 33, 185, 155, 90, 36, 65, 200, 220, 77, 244, 214, 249, 140, 231, 57, 238, 244, 84, 5, 118, 229, 136, 48, 238, 180, 94, 83, 94 } });
        }
    }
}