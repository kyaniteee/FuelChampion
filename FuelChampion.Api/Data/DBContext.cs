using FuelChampion.Api.Data.Config;
using FuelChampion.Api.Models;
using FuelChampion.Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Data;

public class DBContext : IdentityDbContext<User>
{
    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<GasStation> GasStations { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }

    public DBContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        List<IdentityRole> roles = new()
        {
            new() {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new() {
                Name = "User",
                NormalizedName = "USER"
            }
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);
        modelBuilder.ApplyConfiguration(new CarsConfig());
    }
}

