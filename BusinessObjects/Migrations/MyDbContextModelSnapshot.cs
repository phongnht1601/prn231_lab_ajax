﻿// <auto-generated />
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObjects.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Beverages"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Condiments"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Confections"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Dairy Products"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Grains/Cereals"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Meat/Poultry"
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "Produce"
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Seafood"
                        });
                });

            modelBuilder.Entity("BusinessObjects.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductName = "Soda",
                            UnitPrice = 10000m,
                            UnitsInStock = 11
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2,
                            ProductName = "Yellow mustard",
                            UnitPrice = 20000m,
                            UnitsInStock = 21
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            ProductName = "Chocolate layer cake",
                            UnitPrice = 30000m,
                            UnitsInStock = 31
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 4,
                            ProductName = "Cheese",
                            UnitPrice = 40000m,
                            UnitsInStock = 14
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 5,
                            ProductName = "Cereal",
                            UnitPrice = 15000m,
                            UnitsInStock = 15
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 6,
                            ProductName = "Chicken",
                            UnitPrice = 24000m,
                            UnitsInStock = 24
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 7,
                            ProductName = "Melon",
                            UnitPrice = 34000m,
                            UnitsInStock = 31
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 8,
                            ProductName = "Crab",
                            UnitPrice = 45000m,
                            UnitsInStock = 26
                        });
                });

            modelBuilder.Entity("BusinessObjects.Product", b =>
                {
                    b.HasOne("BusinessObjects.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BusinessObjects.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
