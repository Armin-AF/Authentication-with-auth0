using System.ComponentModel.DataAnnotations;

namespace UsedCarWarrantyApi.Models;

public class Vehicle
{
   [Key]
    public int VehicleID { get; set; }
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }
}