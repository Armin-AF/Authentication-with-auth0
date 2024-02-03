using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCarWarrantyApi.Models;

public class WarrantyClaims
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClaimID { get; set; }
        
    [ForeignKey("Warranty")]
    public int WarrantyID { get; set; }
    public Warranty Warranty { get; set; }

    public DateTime? DateFiled { get; set; }
    public string? Status { get; set; } // Consider using an enum
    public string? Description { get; set; }
    public string? ResolutionDetails { get; set; }
}