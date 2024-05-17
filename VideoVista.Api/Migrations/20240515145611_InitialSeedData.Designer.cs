﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VideoVista.Api.Brokers.Storages;

#nullable disable

namespace VideoVista.Api.Migrations
{
    [DbContext(typeof(StorageBroker))]
    [Migration("20240515145611_InitialSeedData")]
    partial class InitialSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VideoVista.Api.Models.VideoMetadatas.VideoMetadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlobPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThubNail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("VideoMetadatas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("47729a8b-e359-493e-a982-e7c818cd1220"),
                            BlobPath = "path",
                            CreatedDate = new DateTimeOffset(new DateTime(2024, 5, 15, 19, 56, 10, 58, DateTimeKind.Unspecified).AddTicks(5563), new TimeSpan(0, 5, 0, 0, 0)),
                            Discription = "FirstDiscription",
                            ThubNail = "thubnail",
                            Title = "Title",
                            UpdatedDate = new DateTimeOffset(new DateTime(2024, 5, 15, 19, 56, 10, 58, DateTimeKind.Unspecified).AddTicks(5591), new TimeSpan(0, 5, 0, 0, 0))
                        });
                });
#pragma warning restore 612, 618
        }
    }
}