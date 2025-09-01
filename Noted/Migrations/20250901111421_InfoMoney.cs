using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Noted.Migrations
{
    /// <inheritdoc />
    public partial class InfoMoney : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoMonies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SingleRoomPrice = table.Column<double>(type: "float", nullable: false),
                    DoubleRoomPrice = table.Column<double>(type: "float", nullable: false),
                    FamilySuitePrice = table.Column<double>(type: "float", nullable: false),
                    AdditionalBedPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoMonies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoMonies_Name",
                table: "InfoMonies",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoMonies");
        }
    }
}
