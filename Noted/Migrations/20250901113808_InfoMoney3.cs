using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noted.Migrations
{
    /// <inheritdoc />
    public partial class InfoMoney3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DuplexPrice",
                table: "InfoMonies",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuplexPrice",
                table: "InfoMonies");
        }
    }
}
