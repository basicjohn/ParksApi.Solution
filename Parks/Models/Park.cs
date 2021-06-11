using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parks.Models
{
  public class Park
  {
    [Required]
    public int ParkId { get; set; }
    [Required]
    public string ParkType { get; set; }
    [Required]
    public string ParkName { get; set; }
    [Required]
    public string ParkDescription { get; set; }
    [Required]
    public int Established { get; set; } = 0;
    [Required]
    public string NearestTown { get; set; }
    [Required]
    public int VisitorCountInPreviousYear { get; set; }
    [Required]
    public int AreaInSquareKm { get; set; }
  }
}




//     public string ParkType {
//     get => foo;
//     set => foo = value >= 0 && value < 6
//         ? value
//         : throw new ArgumentOutOfRangeException("Some useful error message here");
// }
