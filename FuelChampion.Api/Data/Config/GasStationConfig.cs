using FuelChampion.Library.Models;
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

        builder.HasData(
            new()
            {
                City = "Lublin",
                Address = "ul. METALURGICZNA 1C",
                Name = "Shell",
            },
            new()
            {
                City = "Parczew",
                Address = "ul. Hutnicza 3",
                Name = "Stacja Paliw w Parczewie",
            },
            new()
            {
                City = "Lublin",
                Address = "ul. Hutnicza 3",
                Name = "Stacja Paliw w Lublinie",
            },
            new()
            {
                City = "Lublin",
                Address = "ul. Łęczyńska 58",
                Name = "Stacja LPG Łęczyńska",
            },
            new()
            {
                City = "Lublin",
                Address = "ul. Puławska 38",
                Name = "TEZET Sp. z o.o.",
            },
            new()
            {
                City = "Lublin",
                Address = "ul. Frezerów 3",
                Name = "Stacja Auto-Gazu",
            },
            new()
            {
                City = "Lublin",
                Address = "ul. Tulipanowa 72",
                Name = "Władysław Wasiluk - PETRO-BUD-GAZ",
            }
        );
    }
}
