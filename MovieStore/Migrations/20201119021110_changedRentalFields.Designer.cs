﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Models;

namespace MovieStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201119021110_changedRentalFields")]
    partial class changedRentalFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("MovieStore.Models.Age_Rating", b =>
                {
                    b.Property<string>("AgeRating")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AgeRating");

                    b.ToTable("Age_Ratings");
                });

            modelBuilder.Entity("MovieStore.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartOwnerUserNum")
                        .HasColumnType("int");

                    b.Property<bool>("IsRental")
                        .HasColumnType("bit");

                    b.Property<int?>("MovieNum")
                        .HasColumnType("int");

                    b.HasKey("CartId");

                    b.HasIndex("CartOwnerUserNum");

                    b.HasIndex("MovieNum");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("MovieStore.Models.Director", b =>
                {
                    b.Property<int>("DirectorNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectorNum");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("MovieStore.Models.Genre", b =>
                {
                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GenreName");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieStore.Models.Movie", b =>
                {
                    b.Property<int>("MovieNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeRating1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("DirectorNum")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("MovieRating")
                        .HasColumnType("int");

                    b.Property<string>("MovieReleaseDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MovieNum");

                    b.HasIndex("AgeRating1");

                    b.HasIndex("DirectorNum");

                    b.HasIndex("GenreName");

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

                    b.Property<int?>("CustomerUserNum")
                        .HasColumnType("int");

                    b.Property<bool>("IsRental")
                        .HasColumnType("bit");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransactionMovieMovieNum")
                        .HasColumnType("int");

                    b.HasKey("TransactionNum");

                    b.HasIndex("CustomerUserNum");

                    b.HasIndex("TransactionMovieMovieNum");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("MovieStore.Models.TransactionDetails", b =>
                {
                    b.Property<int>("TransactionDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOnCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionDetailsId");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("MovieStore.Models.User", b =>
                {
                    b.Property<int>("UserNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AmountOwed")
                        .HasColumnType("float");

                    b.Property<double>("AmountPaid")
                        .HasColumnType("float");

                    b.Property<int>("RecommendedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("UserCartTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserDOB")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserNum");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieStore.Models.Cart", b =>
                {
                    b.HasOne("MovieStore.Models.User", "CartOwner")
                        .WithMany()
                        .HasForeignKey("CartOwnerUserNum");

                    b.HasOne("MovieStore.Models.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieNum");
                });

            modelBuilder.Entity("MovieStore.Models.Movie", b =>
                {
                    b.HasOne("MovieStore.Models.Age_Rating", "AgeRating")
                        .WithMany()
                        .HasForeignKey("AgeRating1");

                    b.HasOne("MovieStore.Models.Director", "Director")
                        .WithMany()
                        .HasForeignKey("DirectorNum");

                    b.HasOne("MovieStore.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreName");
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
                    b.HasOne("MovieStore.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerUserNum");

                    b.HasOne("MovieStore.Models.Movie", "TransactionMovie")
                        .WithMany()
                        .HasForeignKey("TransactionMovieMovieNum");
                });
#pragma warning restore 612, 618
        }
    }
}
