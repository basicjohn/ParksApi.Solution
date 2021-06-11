using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParkType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    ParkName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    ParkDescription = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    Established = table.Column<int>(type: "int", nullable: false),
                    NearestTown = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: false),
                    VisitorCountInPreviousYear = table.Column<int>(type: "int", nullable: false),
                    AreaInSquareKm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "AreaInSquareKm", "Established", "NearestTown", "ParkDescription", "ParkName", "ParkType", "VisitorCountInPreviousYear" },
                values: new object[] { 1, 8983, 1872, "West Yellowstone, Montana", "Yellowstone National Park is an American national park located in the western United States, largely in the northwest corner of Wyoming and extending into Montana and Idaho. It was established by the U.S. Congress and signed into law by President Ulysses S. Grant on March 1, 1872.[6][7][8] Yellowstone was the first national park in the U.S. and is also widely held to be the first national park in the world.[9] The park is known for its wildlife and its many geothermal features, especially Old Faithful geyser, one of its most popular.[10] While it represents many types of biomes, the subalpine forest is the most abundant. It is part of the South Central Rockies forests ecoregion.", "Yosemite", "National", 3806306 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
