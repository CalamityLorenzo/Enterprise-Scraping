﻿// <auto-generated />
using System;
using DbService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbService.DbModels.DbSearchProvider", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Base64Image")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("BaseUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.ToTable("SearchProviders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a35fbea2-e41e-4692-9071-1c8bb29a0365"),
                            Base64Image = "base64:eee",
                            BaseUrl = "https://www.google.co.uk/search?num=100&q={0}",
                            Created = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4841),
                            Name = "Google",
                            Updated = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4898)
                        },
                        new
                        {
                            Id = new Guid("c5951b98-e351-4561-9ea0-9fa2c59b23d4"),
                            Base64Image = "base64:eee",
                            BaseUrl = "https://www.dogpile.com/serp?q={0}",
                            Created = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4931),
                            Name = "Dogpile",
                            Updated = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4933)
                        },
                        new
                        {
                            Id = new Guid("463981c8-fa6e-4ba2-9ab7-01f89d3b290c"),
                            Base64Image = "base64:eee",
                            BaseUrl = "https://www.google.co.uk/search?num=100&q={0}",
                            Created = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4949),
                            Name = "Google (Alt)",
                            Updated = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4950)
                        });
                });

            modelBuilder.Entity("DbService.DbModels.DbUserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c2d69d70-43e8-4c69-b15f-76e6d052d0d9"),
                            Created = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4979),
                            Name = "Paul",
                            Updated = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(4980)
                        },
                        new
                        {
                            Id = new Guid("d487ae02-e8b7-4b1c-8d3c-5802679dfe66"),
                            Created = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5005),
                            Name = "Sara",
                            Updated = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5006)
                        },
                        new
                        {
                            Id = new Guid("4f8ea409-957b-4296-bf49-7bbce84903ea"),
                            Created = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5021),
                            Name = "Colin",
                            Updated = new DateTime(2024, 3, 19, 12, 10, 24, 346, DateTimeKind.Local).AddTicks(5022)
                        });
                });

            modelBuilder.Entity("DbService.DbModels.DbUserSearch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Positions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SearchTerms")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("SearchTerms");

                    b.ToTable("UserSearches");
                });

            modelBuilder.Entity("DbService.DbModels.DbUserSearch", b =>
                {
                    b.HasOne("DbService.DbModels.DbUserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbService.DbModels.DbSearchProvider", "SearchProvider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SearchProvider");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
