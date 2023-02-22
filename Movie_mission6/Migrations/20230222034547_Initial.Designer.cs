﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie_mission6.Models;

namespace Movie_mission6.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20230222034547_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("Movie_mission6.Models.MovieCategory", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            Category = "Sci-Fi"
                        },
                        new
                        {
                            CategoryID = 2,
                            Category = "Action/Adventure"
                        },
                        new
                        {
                            CategoryID = 3,
                            Category = "Romance"
                        },
                        new
                        {
                            CategoryID = 4,
                            Category = "Comedy"
                        });
                });

            modelBuilder.Entity("Movie_mission6.Models.MovieResponse", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lent_to")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Year")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Responses");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            CategoryID = 2,
                            Director = "George Lucas",
                            Notes = "This is awesome",
                            Rating = "PG-13",
                            Title = "Indiana Jones",
                            Year = 1998
                        },
                        new
                        {
                            MovieID = 2,
                            CategoryID = 1,
                            Director = "George Lucas",
                            Edited = true,
                            Notes = "Amazing film",
                            Rating = "PG",
                            Title = "Star Wars: A New Hope",
                            Year = 1977
                        },
                        new
                        {
                            MovieID = 3,
                            CategoryID = 1,
                            Director = "George Lucas",
                            Edited = false,
                            Notes = "Why Jar Jar",
                            Rating = "PG",
                            Title = "Star Wars: The Phantom Menace",
                            Year = 1999
                        });
                });

            modelBuilder.Entity("Movie_mission6.Models.MovieResponse", b =>
                {
                    b.HasOne("Movie_mission6.Models.MovieCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}