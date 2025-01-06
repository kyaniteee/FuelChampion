using FuelChampion.Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FuelChampion.Api.Data.Config
{
    public class CarsConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");

            builder.HasKey(a => a.Id);

            //builder.Property(a => a.Id)
            //    .HasColumnName("author_id")
            //    .UseIdentityColumn();

            builder.Property(a => a.Model)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("first_name");

            builder.Property(a => a.Producent)
                .IsRequired().HasMaxLength(50)
                .HasColumnName("last_name");

            builder.Property(a => a.ProductionYear)
                .HasMaxLength(50)
                .HasColumnName("middle_name");

            builder.Property(a => a.RegistrationNumber)
                .HasMaxLength(20)
                .HasColumnName("description");

            builder.HasData(new List<Car>()
            {
                new()
                {

                },
                new()
                {

                }
            });

        }
    }
}
