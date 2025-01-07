using FuelChampion.Api.Models.Gas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelChampion.Api.Data.Config;

public class GasStationAvgVoivodeshipPriceConfig : IEntityTypeConfiguration<GasStationAvgVoivodeshipPrice>
{
    public void Configure(EntityTypeBuilder<GasStationAvgVoivodeshipPrice> builder)
    {
        builder.ToView("GasStationAvgVoivodeshipPrices");
        builder.HasNoKey();
    }
}
