
using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
  public class ParksContext : DbContext
  {
    public ParksContext(DbContextOptions<ParksContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
      .HasData(
        new Park
        {
          ParkId = 1,
          ParkType = "National",
          ParkName = "Yosemite",
          ParkDescription = "Yellowstone National Park is an American national park located in the western United States, largely in the northwest corner of Wyoming and extending into Montana and Idaho. It was established by the U.S. Congress and signed into law by President Ulysses S. Grant on March 1, 1872. Yellowstone was the first national park in the U.S. and is also widely held to be the first national park in the world. The park is known for its wildlife and its many geothermal features, especially Old Faithful geyser, one of its most popular. While it represents many types of biomes, the subalpine forest is the most abundant. It is part of the South Central Rockies forests ecoregion.",
          Established = 1872,
          NearestTown = "West Yellowstone, Montana",
          VisitorCountInPreviousYear = 3806306,
          AreaInSquareKm = 8983
        },
        new Park
        {
          ParkId = 2,
          ParkType = "State",
          ParkName = "Chugach",
          ParkDescription = "Chugach State Park covers 495,204 acres (2,004 square kilometers) immediately east of the Anchorage Bowl in south-central Alaska. Though primarily in the Municipality of Anchorage, a small portion of the park north of the Eklutna Lake area in the vicinity of Pioneer Peak lies within the Matanuska-Susitna Borough. Established by legislation signed into law on August 6, 1970, by Alaska Governor Keith Miller, this state park was created to provide recreational opportunities, protect the scenic value of the Chugach Mountains and other geographic features, and ensure the safety of the water supply for Anchorage. The park, managed by Alaska State Parks, is the third-largest state park in the United States, and consists of geographically disparate areas each with different attractions and facilities. Only Anza-Borrego Desert State Park in California and Wood-Tikchik State Park in western Alaska are larger. Hunting and fishing are permitted in the Chugach under regulations established by the Alaska Department of Fish and Game for game management unit 14c. Target practice is not allowed within the park boundaries.",
          Established = 1970,
          NearestTown = "Anchorage, Alaska",
          VisitorCountInPreviousYear = 3806306,
          AreaInSquareKm = 2004
        }
      );
    }
    public DbSet<Park> Parks { get; set; }
  }
}