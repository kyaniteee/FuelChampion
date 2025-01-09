using FuelChampion.Api.Data.Config;
using FuelChampion.Library.Models;
using FuelChampion.Library.Models.Gas;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FuelChampion.Api.Data;

public class DBContext : IdentityDbContext<User>
{
    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<GasStation> GasStations { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }
    public virtual DbSet<GasStationAvgVoivodeshipPrice> GasStationAvgVoivodeshipPrices { get; set; }

    public DBContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<IdentityRole>().HasData(new()
        {
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new()
        {
            Name = "User",
            NormalizedName = "USER"
        });
        modelBuilder.ApplyConfiguration(new CarConfig());
        modelBuilder.ApplyConfiguration(new InvoiceConfig());
        modelBuilder.ApplyConfiguration(new GasStationConfig());
        modelBuilder.ApplyConfiguration(new GasStationAvgVoivodeshipPriceConfig());
    }
}

