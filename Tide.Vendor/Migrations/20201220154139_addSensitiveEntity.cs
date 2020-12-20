using Microsoft.EntityFrameworkCore.Migrations;

namespace Tide.Vendor.Migrations
{
    public partial class addSensitiveEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sensitives",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    DLN = table.Column<string>(nullable: true),
                    TFN = table.Column<string>(nullable: true),
                    Salary = table.Column<string>(nullable: true),
                    Religion = table.Column<string>(nullable: true),
                    PoliticalParty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensitives", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Sensitives_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensitives");
        }
    }
}
