using FuelChampion.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelChampion.Api.Data.Config;

public class InvoicesViewConfig : IEntityTypeConfiguration<InvoiceView>
{
    public void Configure(EntityTypeBuilder<InvoiceView> builder)
    {
        builder.ToView("InvoicesView");
        builder.HasKey(c => c.Invoice_id);
        builder.Property(c => c.Invoice_id).HasColumnName(nameof(InvoiceView.Invoice_id));
        builder.Property(c => c.CarId).IsRequired(false).HasColumnName(nameof(InvoiceView.CarId));
        builder.Property(c => c.UserId).IsRequired().HasColumnName(nameof(InvoiceView.UserId));
        builder.Property(c => c.GasStationId).IsRequired().HasColumnName(nameof(InvoiceView.GasStationId));
        builder.Property(c => c.TotalPrice).IsRequired().HasPrecision(10, 2).HasColumnName(nameof(InvoiceView.TotalPrice));
        builder.Property(c => c.PricePerLiter).IsRequired(false).HasPrecision(10, 2).HasColumnName(nameof(InvoiceView.PricePerLiter));
        builder.Property(c => c.RefuelingDate).IsRequired().HasColumnName(nameof(InvoiceView.RefuelingDate));
        builder.Property(c => c.RefueledLitersAmount).IsRequired().HasPrecision(10, 2).HasColumnName(nameof(InvoiceView.RefueledLitersAmount));
        builder.Property(c => c.FuelType).IsRequired().HasColumnName(nameof(InvoiceView.FuelType));

        builder.Property(a => a.GasStationName).IsRequired(false).HasMaxLength(128).HasColumnName(nameof(InvoiceView.GasStationName));
        builder.Property(a => a.GasStationCity).IsRequired(false).HasMaxLength(128).HasColumnName(nameof(InvoiceView.GasStationCity));
        builder.Property(a => a.GasStationAddress).IsRequired(false).HasMaxLength(256).HasColumnName(nameof(InvoiceView.GasStationAddress));
        builder.Property(a => a.GasStationVoivodeship).IsRequired(false).HasColumnName(nameof(InvoiceView.GasStationVoivodeship));

        builder.Property(a => a.CarProducent).IsRequired(false).HasMaxLength(64).HasColumnName(nameof(InvoiceView.CarProducent));
        builder.Property(a => a.CarModel).IsRequired(false).HasMaxLength(64).HasColumnName(nameof(InvoiceView.CarModel));
        builder.Property(a => a.CarProductionYear).IsRequired(false).HasMaxLength(4).HasColumnName(nameof(InvoiceView.CarProductionYear));
        builder.Property(a => a.CarRegistrationNumber).IsRequired(false).HasMaxLength(8).HasColumnName(nameof(InvoiceView.CarRegistrationNumber));
    }
}
