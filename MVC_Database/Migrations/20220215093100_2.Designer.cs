﻿// <auto-generated />
using MVC_Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220215093100_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVC_Database.Models.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Tele")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Göteborg",
                            Name = "Piff",
                            Tele = "1234567890"
                        },
                        new
                        {
                            Id = 2,
                            City = "Stockholme",
                            Name = "Puff",
                            Tele = "1234565555"
                        },
                        new
                        {
                            Id = 3,
                            City = "Stockö",
                            Name = "Puffspappa",
                            Tele = "123456558"
                        },
                        new
                        {
                            Id = 4,
                            City = "Stockvik",
                            Name = "Puffsmamma",
                            Tele = "1234565559"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
