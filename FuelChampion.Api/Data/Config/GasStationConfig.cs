using FuelChampion.Library.Enums;
using FuelChampion.Library.Models.Gas;
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
        builder.Property(a => a.Voivodeship).IsRequired().HasMaxLength(128).HasColumnName(nameof(GasStation.Voivodeship));

        int id = 1;
        builder.HasData(
            new() { Id = id++, City = "Lublin", Address = "ul. METALURGICZNA 1C", Name = "Shell", Voivodeship = Voivodeship.Lubelskie, },
            new() { Id = id++, City = "Parczew", Address = "ul. Hutnicza 3", Name = "Stacja Paliw w Parczewie", Voivodeship = Voivodeship.Lubelskie, },
            new() { Id = id++, City = "Lublin", Address = "ul. Hutnicza 3", Name = "Stacja Paliw w Lublinie", Voivodeship = Voivodeship.Lubelskie, },
            new() { Id = id++, City = "Lublin", Address = "ul. Łęczyńska 58", Name = "Stacja LPG Łęczyńska", Voivodeship = Voivodeship.Lubelskie, },
            new() { Id = id++, City = "Lublin", Address = "ul. Puławska 38", Name = "TEZET Sp. z o.o.", Voivodeship = Voivodeship.Lubelskie, },
            new() { Id = id++, City = "Lublin", Address = "ul. Frezerów 3", Name = "Stacja Auto-Gazu", Voivodeship = Voivodeship.Lubelskie, },
            new() { Id = id++, City = "Lublin", Address = "ul. Tulipanowa 72", Name = "Władysław Wasiluk - PETRO-BUD-GAZ", Voivodeship = Voivodeship.Lubelskie, }
        );
    }
}
