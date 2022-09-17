using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class WellSchematicAndTrajectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Well_Schematic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Top = table.Column<float>(type: "real", nullable: false),
                    Bottom = table.Column<float>(type: "real", nullable: false),
                    OD = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Well_Schematic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Well_Schematic_Wells_WellId",
                        column: x => x.WellId,
                        principalTable: "Wells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Well_Trajectory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Md = table.Column<float>(type: "real", nullable: false),
                    Tvd = table.Column<float>(type: "real", nullable: false),
                    Inc = table.Column<float>(type: "real", nullable: false),
                    Azi = table.Column<float>(type: "real", nullable: false),
                    North = table.Column<float>(type: "real", nullable: false),
                    East = table.Column<float>(type: "real", nullable: false),
                    WellId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Well_Trajectory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Well_Trajectory_Wells_WellId",
                        column: x => x.WellId,
                        principalTable: "Wells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Well_Schematic_WellId",
                table: "Well_Schematic",
                column: "WellId");

            migrationBuilder.CreateIndex(
                name: "IX_Well_Trajectory_WellId",
                table: "Well_Trajectory",
                column: "WellId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Well_Schematic");

            migrationBuilder.DropTable(
                name: "Well_Trajectory");
        }
    }
}
