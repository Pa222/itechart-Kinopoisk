using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Layer.Migrations
{
    public partial class AddedCreditCardEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cvc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "Id", "CardHolderName", "Cvc", "Expiry", "Image", "Number", "UserId" },
                values: new object[] { 1, "KIRYL KVIT", "522", "04/22", "https://res.cloudinary.com/pa2/image/upload/v1636633366/CreditCardImages/visa_qkcnbw.png", "4556933079048353", 1 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022558/MoviePosters/Venom_2_wg6ejn.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Last_duel_e5rsyn.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Drakulov_pjwsdp.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Uchenosti_Plody_iq3hkx.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Green_MIle_wt2y9b.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Shawshank_crz3n0.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Interstellar_utaka5.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Pulp_Fiction_pwgblb.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/MoviePosters/Inception_uvkvsd.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Avatar",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636538257/UserAvatars/kbroom135_gmail.com_xw2qe1.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_UserId",
                table: "CreditCards",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022558/Venom_2_wg6ejn.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Last_duel_e5rsyn.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Drakulov_pjwsdp.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Uchenosti_Plody_iq3hkx.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Green_MIle_wt2y9b.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Shawshank_crz3n0.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Interstellar_utaka5.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Pulp_Fiction_pwgblb.jpg");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "Image",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636022557/Inception_uvkvsd.jpg");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Avatar",
                value: "https://res.cloudinary.com/pa2/image/upload/v1636538257/kbroom135_gmail.com_xw2qe1.jpg");
        }
    }
}