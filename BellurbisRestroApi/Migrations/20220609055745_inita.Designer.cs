﻿// <auto-generated />
using BellurbisRestroApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BellurbisRestroApi.Migrations
{
    [DbContext(typeof(TaskContaxt))]
    [Migration("20220609055745_inita")]
    partial class inita
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BellurbisRestroApi.Models.LinkMod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("RestroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LinkRAP");
                });

            modelBuilder.Entity("BellurbisRestroApi.Models.PlayersMod", b =>
                {
                    b.Property<int>("PlayersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayersId"), 1L, 1);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerAlternateAdd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerDL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerDOB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerMobNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerOfficeAdd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerPassport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerPrimaryAdd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayersId");

                    b.ToTable("PlayersTab");
                });

            modelBuilder.Entity("BellurbisRestroApi.Models.RestroMod", b =>
                {
                    b.Property<int>("RestroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestroId"), 1L, 1);

                    b.Property<string>("RestroAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestroContact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestroName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestroTiming")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestroId");

                    b.ToTable("Restrotab");
                });
#pragma warning restore 612, 618
        }
    }
}
