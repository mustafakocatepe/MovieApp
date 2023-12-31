﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStudyCase.DataAccess.Context;

#nullable disable

namespace MovieStudyCase.DataAccess.Migrations.MovieApp
{
    [DbContext(typeof(MovieAppContext))]
    [Migration("20231127203404_MovieApp")]
    partial class MovieApp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MovieStudyCase.Entities.Concrete.Director", b =>
                {
                    b.Property<int>("DirectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DirectorId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(7973));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("admin");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DirectorId");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            DirectorId = 1,
                            CreateDate = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8256),
                            CreateUser = "MustafaKocatepe",
                            IsDeleted = false,
                            Name = "Director 1",
                            UpdateUser = "MustafaKocatepe"
                        },
                        new
                        {
                            DirectorId = 2,
                            CreateDate = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8260),
                            CreateUser = "MustafaKocatepe",
                            IsDeleted = false,
                            Name = "Director 2",
                            UpdateUser = "MustafaKocatepe"
                        },
                        new
                        {
                            DirectorId = 3,
                            CreateDate = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8262),
                            CreateUser = "MustafaKocatepe",
                            IsDeleted = false,
                            Name = "Director 3",
                            UpdateUser = "MustafaKocatepe"
                        },
                        new
                        {
                            DirectorId = 4,
                            CreateDate = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8263),
                            CreateUser = "MustafaKocatepe",
                            IsDeleted = false,
                            Name = "Director 4",
                            UpdateUser = "MustafaKocatepe"
                        },
                        new
                        {
                            DirectorId = 5,
                            CreateDate = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8264),
                            CreateUser = "MustafaKocatepe",
                            IsDeleted = false,
                            Name = "Director 5",
                            UpdateUser = "MustafaKocatepe"
                        },
                        new
                        {
                            DirectorId = 6,
                            CreateDate = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8266),
                            CreateUser = "MustafaKocatepe",
                            IsDeleted = false,
                            Name = "Director 6",
                            UpdateUser = "MustafaKocatepe"
                        });
                });

            modelBuilder.Entity("MovieStudyCase.Entities.Concrete.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MovieId"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8664));

                    b.Property<string>("CreateUser")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("admin");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Premier")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 1,
                            CreateDate = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8982),
                            CreateUser = "MustafaKocatepe",
                            Description = "Test Desc",
                            DirectorId = 1,
                            Genre = 0,
                            IsDeleted = false,
                            Name = "Test Movie 1",
                            Premier = new DateTime(2023, 11, 27, 23, 34, 3, 885, DateTimeKind.Local).AddTicks(8981),
                            UpdateUser = "MustafaKocatepe"
                        });
                });

            modelBuilder.Entity("MovieStudyCase.Entities.Concrete.Movie", b =>
                {
                    b.HasOne("MovieStudyCase.Entities.Concrete.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MovieStudyCase.Entities.Concrete.Director", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
