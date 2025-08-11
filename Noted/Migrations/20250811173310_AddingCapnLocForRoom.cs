using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noted.Migrations
{
    /// <inheritdoc />
    public partial class AddingCapnLocForRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomCapacity",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoomLocation",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomCapacity",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "RoomLocation",
                table: "Rooms");
        }
    }
}
