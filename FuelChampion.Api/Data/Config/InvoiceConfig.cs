using FuelChampion.Library.Enums;
using FuelChampion.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelChampion.Api.Data.Config
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Invoice_id");
            builder.Property(c => c.CarId).IsRequired(false).HasColumnName("CarId");
            builder.Property(c => c.UserId).IsRequired().HasColumnName("UserId");
            builder.Property(c => c.GasStationId).IsRequired().HasColumnName("GasStationId");
            builder.Property(c => c.TotalPrice).IsRequired().HasPrecision(10, 2).HasColumnName("TotalPrice");
            builder.Property(c => c.PricePerLiter).IsRequired(false).HasPrecision(10, 2).HasColumnName("PricePerLiter");
            builder.Property(c => c.RefuelingDate).IsRequired().HasColumnName("RefuelingDate");
            builder.Property(c => c.RefueledLitersAmount).IsRequired().HasPrecision(10, 2).HasColumnName("RefueledLitersAmount");
            builder.Property(c => c.FuelType).IsRequired().HasColumnName("FuelType");
        }
    }
}
