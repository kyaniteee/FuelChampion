﻿// <auto-generated />
using System;
using FuelChampion.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuelChampion.Api.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FuelChampion.Library.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Model");

                    b.Property<string>("Producent")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Producent");

                    b.Property<int>("ProductionYear")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("ProductionYear");

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("RegistrationNumber");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)")
                        .HasColumnName("VIN");

                    b.HasKey("Id");

                    b.ToTable("Cars", (string)null);
                });

            modelBuilder.Entity("FuelChampion.Library.Models.Gas.GasStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("City");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("Name");

                    b.Property<int>("Voivodeship")
                        .HasColumnType("int")
                        .HasColumnName("Voivodeship");

                    b.HasKey("Id");

                    b.ToTable("GasStations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "ul. METALURGICZNA 1C",
                            City = "Lublin",
                            Name = "Shell",
                            Voivodeship = 4
                        },
                        new
                        {
                            Id = 2,
                            Address = "ul. Hutnicza 3",
                            City = "Parczew",
                            Name = "Stacja Paliw w Parczewie",
                            Voivodeship = 4
                        },
                        new
                        {
                            Id = 3,
                            Address = "ul. Hutnicza 3",
                            City = "Lublin",
                            Name = "Stacja Paliw w Lublinie",
                            Voivodeship = 4
                        },
                        new
                        {
                            Id = 4,
                            Address = "ul. Łęczyńska 58",
                            City = "Lublin",
                            Name = "Stacja LPG Łęczyńska",
                            Voivodeship = 4
                        },
                        new
                        {
                            Id = 5,
                            Address = "ul. Puławska 38",
                            City = "Lublin",
                            Name = "TEZET Sp. z o.o.",
                            Voivodeship = 4
                        },
                        new
                        {
                            Id = 6,
                            Address = "ul. Frezerów 3",
                            City = "Lublin",
                            Name = "Stacja Auto-Gazu",
                            Voivodeship = 4
                        },
                        new
                        {
                            Id = 7,
                            Address = "ul. Tulipanowa 72",
                            City = "Lublin",
                            Name = "Władysław Wasiluk - PETRO-BUD-GAZ",
                            Voivodeship = 4
                        });
                });

            modelBuilder.Entity("FuelChampion.Library.Models.Gas.GasStationAvgVoivodeshipPrice", b =>
                {
                    b.Property<decimal?>("PricePerLiterAvgDiesel")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PricePerLiterAvgDiesel");

                    b.Property<decimal?>("PricePerLiterAvgLpg")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PricePerLiterAvgLpg");

                    b.Property<decimal?>("PricePerLiterAvgPb95")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PricePerLiterAvgPb95");

                    b.Property<decimal?>("PricePerLiterAvgPb98")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PricePerLiterAvgPb98");

                    b.Property<int?>("Voivodeship")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("GasStationAvgVoivodeshipPrices", (string)null);
                });

            modelBuilder.Entity("FuelChampion.Library.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Invoice_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("CarId");

                    b.Property<int>("FuelType")
                        .HasColumnType("int")
                        .HasColumnName("FuelType");

                    b.Property<int>("GasStationId")
                        .HasColumnType("int")
                        .HasColumnName("GasStationId");

                    b.Property<decimal?>("PricePerLiter")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PricePerLiter");

                    b.Property<decimal>("RefueledLitersAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("RefueledLitersAmount");

                    b.Property<DateTime>("RefuelingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RefuelingDate");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("TotalPrice");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Invoices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            FuelType = 2,
                            GasStationId = 1,
                            PricePerLiter = 5.00m,
                            RefueledLitersAmount = 40m,
                            RefuelingDate = new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 200.00m,
                            UserId = new Guid("6ff8423f-631d-41a3-9c4b-1e706809cb84")
                        },
                        new
                        {
                            Id = 2,
                            CarId = 1,
                            FuelType = 2,
                            GasStationId = 2,
                            PricePerLiter = 5.50m,
                            RefueledLitersAmount = 54m,
                            RefuelingDate = new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TotalPrice = 300.00m,
                            UserId = new Guid("e0bd7101-ecfa-47fc-bc09-b5b87ffa2a4e")
                        });
                });

            modelBuilder.Entity("FuelChampion.Library.Models.InvoiceView", b =>
                {
                    b.Property<int>("Invoice_id")
                        .HasColumnType("int")
                        .HasColumnName("Invoice_id");

                    b.Property<int?>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("CarId");

                    b.Property<string>("CarModel")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("CarModel");

                    b.Property<string>("CarProducent")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("CarProducent");

                    b.Property<int?>("CarProductionYear")
                        .HasMaxLength(4)
                        .HasColumnType("int")
                        .HasColumnName("CarProductionYear");

                    b.Property<string>("CarRegistrationNumber")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasColumnName("CarRegistrationNumber");

                    b.Property<int>("FuelType")
                        .HasColumnType("int")
                        .HasColumnName("FuelType");

                    b.Property<string>("GasStationAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("GasStationAddress");

                    b.Property<string>("GasStationCity")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("GasStationCity");

                    b.Property<int>("GasStationId")
                        .HasColumnType("int")
                        .HasColumnName("GasStationId");

                    b.Property<string>("GasStationName")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("GasStationName");

                    b.Property<int?>("GasStationVoivodeship")
                        .HasColumnType("int")
                        .HasColumnName("GasStationVoivodeship");

                    b.Property<decimal?>("PricePerLiter")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("PricePerLiter");

                    b.Property<decimal>("RefueledLitersAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("RefueledLitersAmount");

                    b.Property<DateTime>("RefuelingDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("RefuelingDate");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("TotalPrice");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Invoice_id");

                    b.ToTable((string)null);

                    b.ToView("InvoicesView", (string)null);
                });

            modelBuilder.Entity("FuelChampion.Library.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("Voivodeship")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "e5fae11a-a8ce-4769-9b2e-b8f8871a04dd",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "f1ed103e-7451-4c2f-9739-68be6e0f7c51",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FuelChampion.Library.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FuelChampion.Library.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuelChampion.Library.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FuelChampion.Library.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
