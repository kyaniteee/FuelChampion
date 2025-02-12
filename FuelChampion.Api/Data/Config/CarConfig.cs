﻿using FuelChampion.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelChampion.Api.Data.Config;

public class CarConfig : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.UserId).IsRequired(true).HasColumnName(nameof(Car.UserId));
        builder.Property(a => a.Producent).IsRequired().HasMaxLength(64).HasColumnName(nameof(Car.Producent));
        builder.Property(a => a.Model).IsRequired().HasMaxLength(64).HasColumnName(nameof(Car.Model));
        builder.Property(a => a.ProductionYear).IsRequired().HasMaxLength(4).HasColumnName(nameof(Car.ProductionYear));
        builder.Property(a => a.RegistrationNumber).IsRequired(false).HasMaxLength(8).HasColumnName(nameof(Car.RegistrationNumber));
        builder.Property(a => a.VIN).IsRequired(false).HasMaxLength(17).HasColumnName(nameof(Car.VIN));
    }
}
