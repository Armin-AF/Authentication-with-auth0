using Microsoft.EntityFrameworkCore;
using UsedCarWarrantyApi.Models;

namespace UsedCarWarrantyApi.Data;

public class WarrantyDbContext: DbContext
{
    public WarrantyDbContext(DbContextOptions<WarrantyDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicle { get; set; } 
    public DbSet<LegalEntity> LegalEntity { get; set; }
    public DbSet<Warranty> Warranty { get; set; } 

    public DbSet<VehicleOwner> VehicleOwner { get; set; } 
    public DbSet<Insurance> Insurance { get; set; }
    public DbSet<WarrantyClaims> WarrantyClaims { get; set; } 

  
}
