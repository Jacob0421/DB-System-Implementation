﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Models;

namespace MovieStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieStore.Models.Actor", b =>
                {
                    b.Property<int>("ActorNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActorFName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActorLName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActorNum");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("MovieStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmountOwed")
                        .HasColumnType("float");

                    b.Property<double>("AmountPaid")
                        .HasColumnType("float");

                    b.Property<string>("CustomerDOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecommendedBy")
                        .HasColumnType("int");

                    b.HasKey("CustomerNum");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MovieStore.Models.Movie", b =>
                {
                    b.Property<int>("MovieNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DirectorNum")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieRating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieNum");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieStore.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(15,2)");

                    b.Property<int?>("TransactionNum")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("TransactionNum");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("MovieStore.Models.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DaysLate")
                        .HasColumnType("int");

                    b.Property<bool>("IsLate")
                        .HasColumnType("bit");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("decimal(15,2)");

                    b.Property<int?>("TransactionNum")
                        .HasColumnType("int");

                    b.HasKey("RentalId");

                    b.HasIndex("TransactionNum");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("MovieStore.Models.Review", b =>
                {
                    b.Property<int>("ReviewNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieNum")
                        .HasColumnType("int");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.HasKey("ReviewNum");

                    b.HasIndex("MovieNum");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MovieStore.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerNum")
                        .HasColumnType("int");

                    b.Property<bool>("IsRental")
                        .HasColumnType("bit");

                    b.Property<int?>("MovieNum")
                        .HasColumnType("int");

                    b.Property<string>("tTansactionDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionNum");

                    b.HasIndex("CustomerNum");

                    b.HasIndex("MovieNum");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MovieStore.Models.Purchase", b =>
                {
                    b.HasOne("MovieStore.Models.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionNum");
                });

            modelBuilder.Entity("MovieStore.Models.Rental", b =>
                {
                    b.HasOne("MovieStore.Models.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionNum");
                });

            modelBuilder.Entity("MovieStore.Models.Review", b =>
                {
                    b.HasOne("MovieStore.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieNum");
                });

            modelBuilder.Entity("MovieStore.Models.Transaction", b =>
                {
                    b.HasOne("MovieStore.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerNum");

                    b.HasOne("MovieStore.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieNum");
                });
#pragma warning restore 612, 618
        }
    }
}
