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

            builder.Property(c => c.Id)
                .HasColumnName("Invoice_id");

            builder.Property(c => c.CarId)
                .IsRequired(false)
                .HasMaxLength(10)
                .HasColumnName("CarId");

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("UserId");

            builder.Property(c => c.GasStationId)
                .HasMaxLength(10)
                .IsRequired()
                .HasColumnName("GasStationId");

            builder.Property(c => c.TotalPrice)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("TotalPrice");

            builder.Property(c => c.PricePerLiter)
                .HasMaxLength(20)
                .IsRequired(false)
                .HasColumnName("PricePerLiter");

            builder.Property(c => c.RefuelingDate)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("RefuelingDate");

            builder.Property(c => c.RefueledLitersAmount)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("RefueledLitersAmount");

            builder.Property(c => c.FuelType)
                .HasMaxLength(20)
                .IsRequired()
                .HasColumnName("FuelType");

            builder.HasData(
            new()
            {
                Id = 1,
                CarId = 1,
                UserId = Guid.NewGuid(),
                GasStationId = 1,
                TotalPrice = 200.00m,
                PricePerLiter = 5.00m,
                RefuelingDate = new(2024, 12, 25),
                RefueledLitersAmount = 40,
                FuelType = FuelType.Pb98E5
            },
            new()
            {
                Id = 2,
                CarId = 1,
                UserId = Guid.NewGuid(),
                GasStationId = 2,
                TotalPrice = 300.00m,
                PricePerLiter = 5.50m,
                RefuelingDate = new(2025, 1, 5),
                RefueledLitersAmount = 54,
                FuelType = FuelType.Pb98E5
            });
        }
    }
}
