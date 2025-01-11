using FuelChampion.Library.Models.Gas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelChampion.Api.Data.Config;

public class GasStationAvgVoivodeshipPriceConfig : IEntityTypeConfiguration<GasStationAvgVoivodeshipPrice>
{
    public void Configure(EntityTypeBuilder<GasStationAvgVoivodeshipPrice> builder)
    {
        builder.ToView("GasStationAvgVoivodeshipPrices");
        builder.HasNoKey();
        builder.Property(c => c.PricePerLiterAvgPb98).HasPrecision(10, 2).HasColumnName("PricePerLiterAvgPb98");
        builder.Property(c => c.PricePerLiterAvgPb95).HasPrecision(10, 2).HasColumnName("PricePerLiterAvgPb95");
        builder.Property(c => c.PricePerLiterAvgDiesel).HasPrecision(10, 2).HasColumnName("PricePerLiterAvgDiesel");
        builder.Property(c => c.PricePerLiterAvgLpg).HasPrecision(10, 2).HasColumnName("PricePerLiterAvgLpg");
    }
}
