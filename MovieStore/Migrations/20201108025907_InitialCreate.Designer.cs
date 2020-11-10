﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStore.Models;

namespace MovieStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201108025907_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
#pragma warning restore 612, 618
        }
    }
}
