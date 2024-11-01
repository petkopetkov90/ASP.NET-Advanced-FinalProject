﻿// <auto-generated />
using System;
using FleetRouteManager.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetRouteManager.Data.Migrations
{
    [DbContext(typeof(FleetRouteManagerDbContext))]
    partial class FleetRouteManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FleetRouteManager.Data.Models.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key for Manufacturer entity");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Deletion date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Soft Delete");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Manufacturer Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Mercedes"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Ford"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Renault"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Volkswagen"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Iveco"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Man"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Scania"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "Volvo"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "Schmitz"
                        },
                        new
                        {
                            Id = 10,
                            IsDeleted = false,
                            Name = "Krone"
                        },
                        new
                        {
                            Id = 11,
                            IsDeleted = false,
                            Name = "Fruehauf"
                        },
                        new
                        {
                            Id = 12,
                            IsDeleted = false,
                            Name = "Peugeot"
                        });
                });

            modelBuilder.Entity("FleetRouteManager.Data.Models.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key for Vehicle entity");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Vehicle Date of Purchase");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date and time when the vehicle was marked as deleted");

                    b.Property<string>("EuroClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Vehicle Emission Class");

                    b.Property<DateTime>("FirstRegistration")
                        .HasColumnType("datetime2")
                        .HasComment("Vehicle First Registration");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Indicates if the vehicle was deleted");

                    b.Property<string>("LiabilityInsurance")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Vehicle Liability Insurance policy number");

                    b.Property<DateTime?>("LiabilityInsuranceExpirationDate")
                        .HasColumnType("datetime2")
                        .HasComment("Vehicle Liability Insurance expiration date");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int")
                        .HasComment("Foreign key to the Manufacturer");

                    b.Property<string>("Model")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("Vehicle Model");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Vehicle Registration Number");

                    b.Property<DateTime?>("TachographExpirationDate")
                        .HasColumnType("datetime2")
                        .HasComment("Vehicle Tachograph Certification expiration date");

                    b.Property<DateTime?>("TechnicalReviewExpirationDate")
                        .HasColumnType("datetime2")
                        .HasComment("Vehicle Technical Review expiration date");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int")
                        .HasComment("Foreign key to the VehicleType");

                    b.Property<string>("Vin")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("VIN")
                        .HasComment("Vehicle VIN/Frame number");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("RegistrationNumber")
                        .IsUnique();

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedOn = new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            EuroClass = "Euro6",
                            FirstRegistration = new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDeleted = false,
                            LiabilityInsurance = "010/LEV/1111111111-11",
                            LiabilityInsuranceExpirationDate = new DateTime(2025, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            ManufacturerId = 1,
                            Model = "Atego",
                            RegistrationNumber = "CB 1111 CB",
                            VehicleTypeId = 1,
                            Vin = "MER1111111111"
                        },
                        new
                        {
                            Id = 2,
                            AddedOn = new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            EuroClass = "Euro5",
                            FirstRegistration = new DateTime(2023, 9, 28, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDeleted = false,
                            LiabilityInsurance = "020/LEV/2222222222-22",
                            LiabilityInsuranceExpirationDate = new DateTime(2025, 7, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            ManufacturerId = 6,
                            Model = "TGL",
                            RegistrationNumber = "CB 2222 CB",
                            TechnicalReviewExpirationDate = new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Local),
                            VehicleTypeId = 2,
                            Vin = "MAN2222222222"
                        },
                        new
                        {
                            Id = 3,
                            AddedOn = new DateTime(2024, 10, 18, 0, 0, 0, 0, DateTimeKind.Local),
                            EuroClass = "Euro5",
                            FirstRegistration = new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDeleted = false,
                            LiabilityInsurance = "030/LEV/3333333333-33",
                            LiabilityInsuranceExpirationDate = new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            ManufacturerId = 6,
                            Model = "TGL",
                            RegistrationNumber = "CB 3333 CB",
                            TachographExpirationDate = new DateTime(2025, 1, 16, 0, 0, 0, 0, DateTimeKind.Local),
                            VehicleTypeId = 3,
                            Vin = "MAN3333333333"
                        },
                        new
                        {
                            Id = 4,
                            AddedOn = new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            EuroClass = "Euro4",
                            FirstRegistration = new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            IsDeleted = false,
                            LiabilityInsurance = "040/LEV/4444444444-44",
                            LiabilityInsuranceExpirationDate = new DateTime(2024, 12, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            ManufacturerId = 7,
                            Model = "R420",
                            RegistrationNumber = "CB 4444 CB",
                            TachographExpirationDate = new DateTime(2025, 1, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            TechnicalReviewExpirationDate = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Local),
                            VehicleTypeId = 3,
                            Vin = "SCA4444444444"
                        });
                });

            modelBuilder.Entity("FleetRouteManager.Data.Models.Models.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary Key for VehicleType");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Axles")
                        .HasColumnType("int")
                        .HasComment("Vehicle number of axles");

                    b.Property<string>("BodyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Body type");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Deletion date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasComment("Soft Delete");

                    b.Property<string>("TruckType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Truck type");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Vehicle type name");

                    b.Property<double>("WeightCapacity")
                        .HasColumnType("float")
                        .HasComment("Total capacity in tons");

                    b.HasKey("Id");

                    b.ToTable("VehicleTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Axles = 2,
                            BodyType = "Curtain",
                            IsDeleted = false,
                            TruckType = "Truck",
                            TypeName = "Solo 7.5t",
                            WeightCapacity = 1.6299999999999999
                        },
                        new
                        {
                            Id = 2,
                            Axles = 2,
                            BodyType = "Curtain",
                            IsDeleted = false,
                            TruckType = "Truck",
                            TypeName = "Solo 12.0t",
                            WeightCapacity = 4.2999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Axles = 3,
                            BodyType = "Curtain",
                            IsDeleted = false,
                            TruckType = "Truck",
                            TypeName = "Solo 18.0t",
                            WeightCapacity = 9.8000000000000007
                        },
                        new
                        {
                            Id = 4,
                            Axles = 3,
                            BodyType = "Curtain",
                            IsDeleted = false,
                            TruckType = "Truck",
                            TypeName = "Solo 26.0t",
                            WeightCapacity = 14.0
                        },
                        new
                        {
                            Id = 5,
                            Axles = 2,
                            BodyType = "None",
                            IsDeleted = false,
                            TruckType = "Tractor",
                            TypeName = "Tractor",
                            WeightCapacity = 0.0
                        },
                        new
                        {
                            Id = 6,
                            Axles = 2,
                            BodyType = "Box",
                            IsDeleted = false,
                            TruckType = "Van",
                            TypeName = "Van 3.5t",
                            WeightCapacity = 1.3300000000000001
                        },
                        new
                        {
                            Id = 7,
                            Axles = 3,
                            BodyType = "Open",
                            IsDeleted = false,
                            TruckType = "Semitrailer",
                            TypeName = "Semitrailer",
                            WeightCapacity = 24.989999999999998
                        },
                        new
                        {
                            Id = 8,
                            Axles = 2,
                            BodyType = "Open",
                            IsDeleted = false,
                            TruckType = "Trailer",
                            TypeName = "Trailer",
                            WeightCapacity = 8.0999999999999996
                        });
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FleetRouteManager.Data.Models.Models.Vehicle", b =>
                {
                    b.HasOne("FleetRouteManager.Data.Models.Models.Manufacturer", "Manufacturer")
                        .WithMany("Vehicles")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("FleetRouteManager.Data.Models.Models.VehicleType", "VehicleType")
                        .WithMany("Vehicles")
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Manufacturer");

                    b.Navigation("VehicleType");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FleetRouteManager.Data.Models.Models.Manufacturer", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("FleetRouteManager.Data.Models.Models.VehicleType", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
