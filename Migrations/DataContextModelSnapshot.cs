﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyStore.Services.Context;

namespace MyStore.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyStore.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSaleItem")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("InventoryItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "#2 pencil",
                            IsSaleItem = false,
                            Name = "Pencil",
                            Price = 0.5,
                            Quantity = 100,
                            Sku = "38830982031",
                            StorageLocation = "A1"
                        },
                        new
                        {
                            Id = 2,
                            Description = "spiral notebook",
                            IsSaleItem = false,
                            Name = "Notebook",
                            Price = 1.5,
                            Quantity = 50,
                            Sku = "3881111131",
                            StorageLocation = "A2"
                        },
                        new
                        {
                            Id = 3,
                            Description = "3 ring binder with dividers",
                            IsSaleItem = false,
                            Name = "Binder",
                            Price = 4.5,
                            Quantity = 5,
                            Sku = "54830982031",
                            StorageLocation = "A2"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Scientific calculator",
                            IsSaleItem = false,
                            Name = "Ti83+ Calculator",
                            Price = 49.0,
                            Quantity = 100,
                            Sku = "3889462031",
                            StorageLocation = "A4"
                        },
                        new
                        {
                            Id = 5,
                            Description = "black ball point pen",
                            IsSaleItem = false,
                            Name = "Pen",
                            Price = 0.5,
                            Quantity = 10,
                            Sku = "388309867",
                            StorageLocation = "A1"
                        },
                        new
                        {
                            Id = 6,
                            Description = "metallic coaster",
                            IsSaleItem = false,
                            Name = "Coaster",
                            Price = 5.5,
                            Quantity = 1,
                            Sku = "388309212",
                            StorageLocation = "A6"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Fuzzy backpack",
                            IsSaleItem = false,
                            Name = "Backpack",
                            Price = 25.489999999999998,
                            Quantity = 100,
                            Sku = "388309987",
                            StorageLocation = "A5"
                        });
                });

            modelBuilder.Entity("MyStore.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cash"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Credit"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Debit"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Check"
                        },
                        new
                        {
                            Id = 5,
                            Name = "GiftCard"
                        });
                });

            modelBuilder.Entity("MyStore.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("InventoryItemId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfBuyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SalesTax")
                        .HasColumnType("float");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("InventoryItemId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("PurchaseOrders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Datetime = new DateTime(2020, 3, 8, 11, 57, 37, 343, DateTimeKind.Local).AddTicks(8561),
                            InventoryItemId = 1,
                            NameOfBuyer = "John Doe",
                            PaymentTypeId = 1,
                            Quantity = 2,
                            SalesTax = 0.25,
                            Subtotal = 1.0
                        },
                        new
                        {
                            Id = 2,
                            Datetime = new DateTime(2020, 3, 7, 11, 57, 37, 344, DateTimeKind.Local).AddTicks(762),
                            InventoryItemId = 3,
                            NameOfBuyer = "Mildred Smith",
                            PaymentTypeId = 3,
                            Quantity = 4,
                            SalesTax = 4.5,
                            Subtotal = 18.0
                        });
                });

            modelBuilder.Entity("MyStore.Models.PurchaseOrder", b =>
                {
                    b.HasOne("MyStore.Models.InventoryItem", "Item")
                        .WithMany()
                        .HasForeignKey("InventoryItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyStore.Models.PaymentType", "PaymentType")
                        .WithMany()
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
