using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Layer.Migrations
{
    public partial class AddeduserSaltPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Users",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "Password", "Salt" },
                values: new object[] { "https://res.cloudinary.com/pa2/image/upload/v1636538257/kbroom135_gmail.com_xw2qe1.jpg", "7uGP9aeazU4F7QhxLc3fEkBMcZn5AyQqeDq6MLxBO6Y", new byte[] { 143, 188, 230, 183, 101, 3, 38, 186, 29, 23, 147, 73, 165, 102, 250, 161 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Avatar", "Password" },
                values: new object[] { "https://res.cloudinary.com/pa2/image/upload/v1636535929/user_fhguim.png", "112233" });
        }
    }
}
