using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCarWarrantyApi.Models;

public class Warranty
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int WarrantyID { get; set; }

    [ForeignKey("Vehicle")]
    public int VehicleID { get; set; }
    public Vehicle Vehicle { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string CoverageDetails { get; set; }
}