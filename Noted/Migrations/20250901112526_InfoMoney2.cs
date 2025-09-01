using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noted.Migrations
{
    /// <inheritdoc />
    public partial class InfoMoney2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SingleRoomPrice",
                table: "InfoMonies",
                newName: "SingleRoomPriceFC2");

            migrationBuilder.RenameColumn(
                name: "DoubleRoomPrice",
                table: "InfoMonies",
                newName: "SingleRoomPriceFC1");

            migrationBuilder.AddColumn<double>(
                name: "DoubleRoomPriceFC1",
                table: "InfoMonies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DoubleRoomPriceFC2",
                table: "InfoMonies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoubleRoomPriceFC1",
                table: "InfoMonies");

            migrationBuilder.DropColumn(
                name: "DoubleRoomPriceFC2",
                table: "InfoMonies");

            migrationBuilder.RenameColumn(
                name: "SingleRoomPriceFC2",
                table: "InfoMonies",
                newName: "SingleRoomPrice");

            migrationBuilder.RenameColumn(
                name: "SingleRoomPriceFC1",
                table: "InfoMonies",
                newName: "DoubleRoomPrice");
        }
    }
}
