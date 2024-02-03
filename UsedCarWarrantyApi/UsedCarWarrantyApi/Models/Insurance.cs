using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCarWarrantyApi.Models;

public class Insurance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int InsuranceID { get; set; }

    [ForeignKey("LegalEntity")]
    public int EntityID { get; set; }
    public LegalEntity LegalEntity { get; set; }

    [ForeignKey("Vehicle")]
    public int VehicleID { get; set; }
    public Vehicle Vehicle { get; set; }

    public string Provider { get; set; }
    public string PolicyNumber { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}