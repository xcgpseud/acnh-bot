﻿// <auto-generated />
using ACNHBot.Application.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ACNHBot.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20200524103131_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.4.20220.10");

            modelBuilder.Entity("ACNHBot.Application.Database.Entities.ArtEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Genuine")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<int>("InternalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MuseumDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("RealArtworkTitle")
                        .HasColumnType("TEXT");

                    b.Property<int>("SellPrice")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Arts");
                });
#pragma warning restore 612, 618
        }
    }
}
