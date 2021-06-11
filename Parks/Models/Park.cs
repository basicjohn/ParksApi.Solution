using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Parks.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string ParkType { get; set; }
    public string ParkName { get; set; }
    public string ParkDescription { get; set; }
    public int Established { get; set; }
    public int VisitorCountInPreviousYear { get; set; }
    public int AreaInSquareMiles { get; set; }
  }
}




//     public string ParkType {
//     get => foo;
//     set => foo = value >= 0 && value < 6
//         ? value
//         : throw new ArgumentOutOfRangeException("Some useful error message here");
// }
