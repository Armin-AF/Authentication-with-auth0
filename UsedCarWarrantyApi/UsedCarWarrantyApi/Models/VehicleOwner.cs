using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCarWarrantyApi.Models;

public class VehicleOwner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OwnershipID { get; set; }
        
    [ForeignKey("Vehicle")]
    public int VehicleID { get; set; }
    public Vehicle Vehicle { get; set; }

    [ForeignKey("LegalEntity")]
    public int EntityID { get; set; }
    public LegalEntity LegalEntity { get; set; }

    public DateTime PurchaseDate { get; set; }
    public DateTime? SaleDate { get; set; }
}