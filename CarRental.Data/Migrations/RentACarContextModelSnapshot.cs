﻿// <auto-generated />
using System;
using CarRental.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarRental.Data.Migrations
{
    [DbContext(typeof(RentACarContext))]
    partial class RentACarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarRental.Domain.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AfterKm");

                    b.Property<int>("BeforeKm");

                    b.Property<int?>("CarId");

                    b.Property<int?>("CustomerId");

                    b.Property<int>("ReferenceNumber");

                    b.Property<DateTime>("RentEndDate");

                    b.Property<DateTime>("RentStartDate");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("CarRental.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarBrand");

                    b.Property<string>("CarColor");

                    b.Property<int>("CarFuelTypes");

                    b.Property<int>("CarKm");

                    b.Property<string>("CarLocation");

                    b.Property<string>("CarModel");

                    b.Property<int>("CarYear");

                    b.Property<bool>("IsManual");

                    b.HasKey("Id");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("CarRental.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerEmail");

                    b.Property<string>("CustomerName");

                    b.Property<string>("CustomerPhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CarRental.Domain.CustomerProperties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<int>("TypeId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerProperties");
                });

            modelBuilder.Entity("CarRental.Domain.PriceTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId");

                    b.Property<int>("CarPrice");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("PriceTable");
                });

            modelBuilder.Entity("CarRental.Domain.Book", b =>
                {
                    b.HasOne("CarRental.Domain.Car", "Car")
                        .WithMany("Books")
                        .HasForeignKey("CarId");

                    b.HasOne("CarRental.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("CarRental.Domain.CustomerProperties", b =>
                {
                    b.HasOne("CarRental.Domain.Customer")
                        .WithMany("CustomerProperties")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("CarRental.Domain.PriceTable", b =>
                {
                    b.HasOne("CarRental.Domain.Car")
                        .WithMany("PriceTables")
                        .HasForeignKey("CarId");
                });
#pragma warning restore 612, 618
        }
    }
}
