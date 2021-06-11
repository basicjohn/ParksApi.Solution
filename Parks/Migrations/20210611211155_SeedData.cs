using Microsoft.EntityFrameworkCore.Migrations;

namespace Parks.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1,
                column: "ParkDescription",
                value: "Yellowstone National Park is an American national park located in the western United States, largely in the northwest corner of Wyoming and extending into Montana and Idaho. It was established by the U.S. Congress and signed into law by President Ulysses S. Grant on March 1, 1872. Yellowstone was the first national park in the U.S. and is also widely held to be the first national park in the world. The park is known for its wildlife and its many geothermal features, especially Old Faithful geyser, one of its most popular. While it represents many types of biomes, the subalpine forest is the most abundant. It is part of the South Central Rockies forests ecoregion.");

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "AreaInSquareKm", "Established", "NearestTown", "ParkDescription", "ParkName", "ParkType", "VisitorCountInPreviousYear" },
                values: new object[] { 2, 2004, 1970, "Anchorage, Alaska", "Chugach State Park covers 495,204 acres (2,004 square kilometers) immediately east of the Anchorage Bowl in south-central Alaska. Though primarily in the Municipality of Anchorage, a small portion of the park north of the Eklutna Lake area in the vicinity of Pioneer Peak lies within the Matanuska-Susitna Borough. Established by legislation signed into law on August 6, 1970, by Alaska Governor Keith Miller, this state park was created to provide recreational opportunities, protect the scenic value of the Chugach Mountains and other geographic features, and ensure the safety of the water supply for Anchorage. The park, managed by Alaska State Parks, is the third-largest state park in the United States, and consists of geographically disparate areas each with different attractions and facilities. Only Anza-Borrego Desert State Park in California and Wood-Tikchik State Park in western Alaska are larger. Hunting and fishing are permitted in the Chugach under regulations established by the Alaska Department of Fish and Game for game management unit 14c. Target practice is not allowed within the park boundaries.", "Chugach", "State", 3806306 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1,
                column: "ParkDescription",
                value: "Yellowstone National Park is an American national park located in the western United States, largely in the northwest corner of Wyoming and extending into Montana and Idaho. It was established by the U.S. Congress and signed into law by President Ulysses S. Grant on March 1, 1872.[6][7][8] Yellowstone was the first national park in the U.S. and is also widely held to be the first national park in the world.[9] The park is known for its wildlife and its many geothermal features, especially Old Faithful geyser, one of its most popular.[10] While it represents many types of biomes, the subalpine forest is the most abundant. It is part of the South Central Rockies forests ecoregion.");
        }
    }
}
