using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Management.Migrations
{
    /// <inheritdoc />
    public partial class Room : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ConferenceRooms_ConferenceRoomId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceRoomId",
                table: "Services",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConferenceRoomId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConferenceRoomId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConferenceRoomId",
                value: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ConferenceRooms_ConferenceRoomId",
                table: "Services",
                column: "ConferenceRoomId",
                principalTable: "ConferenceRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_ConferenceRooms_ConferenceRoomId",
                table: "Services");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceRoomId",
                table: "Services",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConferenceRoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConferenceRoomId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConferenceRoomId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ConferenceRooms_ConferenceRoomId",
                table: "Services",
                column: "ConferenceRoomId",
                principalTable: "ConferenceRooms",
                principalColumn: "Id");
        }
    }
}
