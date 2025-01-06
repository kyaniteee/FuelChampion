using FuelChampion.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelChampion.Api.Data.Config;

public class GasStationConfig : IEntityTypeConfiguration<GasStation>
{
    public void Configure(EntityTypeBuilder<GasStation> builder)
    {
        builder.ToTable("GasStations");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(128).HasColumnName(nameof(GasStation.Name));
        builder.Property(a => a.City).IsRequired().HasMaxLength(128).HasColumnName(nameof(GasStation.City));
        builder.Property(a => a.Address).IsRequired().HasMaxLength(256).HasColumnName(nameof(GasStation.Address));

        int id = 1;
        builder.HasData(
            new() { Id = id++, City = "Lublin", Address = "ul. METALURGICZNA 1C", Name = "Shell", },
            new() { Id = id++, City = "Parczew", Address = "ul. Hutnicza 3", Name = "Stacja Paliw w Parczewie", },
            new() { Id = id++, City = "Lublin", Address = "ul. Hutnicza 3", Name = "Stacja Paliw w Lublinie", },
            new() { Id = id++, City = "Lublin", Address = "ul. Łęczyńska 58", Name = "Stacja LPG Łęczyńska", },
            new() { Id = id++, City = "Lublin", Address = "ul. Puławska 38", Name = "TEZET Sp. z o.o.", },
            new() { Id = id++, City = "Lublin", Address = "ul. Frezerów 3", Name = "Stacja Auto-Gazu", },
            new() { Id = id++, City = "Lublin", Address = "ul. Tulipanowa 72", Name = "Władysław Wasiluk - PETRO-BUD-GAZ", }
        );
    }
}
