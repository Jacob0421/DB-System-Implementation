﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Models;

namespace MovieStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201125161202_AddedNumberOfMovies")]
    partial class AddedNumberOfMovies
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MovieStore.Models.Actor", b =>
                {
                    b.Property<int>("ActorNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ActorFName")
                        .HasColumnType("text");

                    b.Property<string>("ActorLName")
                        .HasColumnType("text");

                    b.Property<int?>("ActorMovieMovieNum")
                        .HasColumnType("int");

                    b.HasKey("ActorNum");

                    b.HasIndex("ActorMovieMovieNum");

                    b.ToTable("Actor");
                });

            modelBuilder.Entity("MovieStore.Models.Age_Rating", b =>
                {
                    b.Property<string>("AgeRating")
                        .HasColumnType("varchar(767)");

                    b.HasKey("AgeRating");

                    b.ToTable("Age_Ratings");
                });

            modelBuilder.Entity("MovieStore.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CartOwnerUserNum")
                        .HasColumnType("int");

                    b.Property<bool>("IsRental")
                        .HasColumnType("tinyint(1)");

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
                        .HasColumnType("int");

                    b.Property<string>("FName")
                        .HasColumnType("text");

                    b.Property<string>("LName")
                        .HasColumnType("text");

                    b.HasKey("DirectorNum");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("MovieStore.Models.Genre", b =>
                {
                    b.Property<string>("GenreName")
                        .HasColumnType("varchar(767)");

                    b.HasKey("GenreName");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("MovieStore.Models.Movie", b =>
                {
                    b.Property<int>("MovieNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AgeRating1")
                        .HasColumnType("varchar(767)");

                    b.Property<int?>("DirectorNum")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("varchar(767)");

                    b.Property<bool>("IsNewRelease")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("MovieInventory")
                        .HasColumnType("int");

                    b.Property<decimal>("MovieRating")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("MovieReleaseDate")
                        .HasColumnType("text");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfReviews")
                        .HasColumnType("int");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("RentalPrice")
                        .HasColumnType("decimal(18, 2)");

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
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseTransactionTransactionNum")
                        .HasColumnType("int");

                    b.HasKey("PurchaseId");

                    b.HasIndex("PurchaseTransactionTransactionNum");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("MovieStore.Models.Rental", b =>
                {
                    b.Property<int>("RentalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DaysLate")
                        .HasColumnType("int");

                    b.Property<string>("DueDate")
                        .HasColumnType("text");

                    b.Property<bool>("IsLate")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("RentalFinalCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int?>("RentalTransactionTransactionNum")
                        .HasColumnType("int");

                    b.Property<bool>("Returned")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("RentalId");

                    b.HasIndex("RentalTransactionTransactionNum");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("MovieStore.Models.Review", b =>
                {
                    b.Property<int>("ReviewNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AuthorUserNum")
                        .HasColumnType("int");

                    b.Property<int?>("MovieNum")
                        .HasColumnType("int");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("text");

                    b.Property<string>("ReviewBody")
                        .HasColumnType("text");

                    b.Property<string>("ReviewDate")
                        .HasColumnType("text");

                    b.Property<string>("ReviewTitle")
                        .HasColumnType("text");

                    b.Property<int>("StarRating")
                        .HasColumnType("int");

                    b.HasKey("ReviewNum");

                    b.HasIndex("AuthorUserNum");

                    b.HasIndex("MovieNum");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MovieStore.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CustomerUserNum")
                        .HasColumnType("int");

                    b.Property<bool>("IsRental")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TransactionDate")
                        .HasColumnType("text");

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
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreditCardNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("MainTransactionTransactionNum")
                        .HasColumnType("int");

                    b.Property<string>("NameOnCard")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TransactionDetailsId");

                    b.HasIndex("MainTransactionTransactionNum");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("MovieStore.Models.User", b =>
                {
                    b.Property<int>("UserNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("AmountOwed")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("RecommendedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("UserCartTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("UserDOB")
                        .HasColumnType("text");

                    b.Property<string>("UserFirstName")
                        .HasColumnType("text");

                    b.Property<string>("UserLastName")
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .HasColumnType("text");

                    b.Property<string>("UserUserName")
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .HasColumnType("text");

                    b.HasKey("UserNum");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MovieStore.Models.Actor", b =>
                {
                    b.HasOne("MovieStore.Models.Movie", "ActorMovie")
                        .WithMany()
                        .HasForeignKey("ActorMovieMovieNum");
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
                    b.HasOne("MovieStore.Models.Transaction", "PurchaseTransaction")
                        .WithMany()
                        .HasForeignKey("PurchaseTransactionTransactionNum");
                });

            modelBuilder.Entity("MovieStore.Models.Rental", b =>
                {
                    b.HasOne("MovieStore.Models.Transaction", "RentalTransaction")
                        .WithMany()
                        .HasForeignKey("RentalTransactionTransactionNum");
                });

            modelBuilder.Entity("MovieStore.Models.Review", b =>
                {
                    b.HasOne("MovieStore.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorUserNum");

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

            modelBuilder.Entity("MovieStore.Models.TransactionDetails", b =>
                {
                    b.HasOne("MovieStore.Models.Transaction", "MainTransaction")
                        .WithMany()
                        .HasForeignKey("MainTransactionTransactionNum");
                });
#pragma warning restore 612, 618
        }
    }
}
