using System.ComponentModel.DataAnnotations;
namespace Noted.Models;

public class InfoMoney
{
    [Key]
    public int Id { get; set; }

    [Required] // unique constraint is enforced in DbContext
    public string Name { get; set; }
    [Required]
    public double SingleRoomPriceFC1 { get; set; }
    [Required]
    public double SingleRoomPriceFC2 { get; set; }
    [Required]
    public double DoubleRoomPriceFC1 { get; set; }
    [Required]
    public double DoubleRoomPriceFC2 { get; set; }
    [Required]
    public double FamilySuitePrice { get; set; }
    [Required]
    public double AdditionalBedPrice { get; set; }
    [Required]
    public double DuplexPrice { get; set; } = 2300;

}