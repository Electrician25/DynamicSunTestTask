﻿// <auto-generated />
using DynamicSunTestTask.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DynamicSunTestTask.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240316143451_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DynamicSunTestTask.Entites.WheatherColumnEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("AirHumidity")
                        .HasColumnType("double precision");

                    b.Property<double>("Cloudy")
                        .HasColumnType("double precision");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("DewPoint")
                        .HasColumnType("double precision");

                    b.Property<string>("DirectionOfTheWind")
                        .HasColumnType("text");

                    b.Property<string>("HorizontalVisibility")
                        .HasColumnType("text");

                    b.Property<double>("LowerCloudLimit")
                        .HasColumnType("double precision");

                    b.Property<string>("MoskowTime")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Pressure")
                        .HasColumnType("double precision");

                    b.Property<double>("Temperature")
                        .HasColumnType("double precision");

                    b.Property<string>("WeatherConditions")
                        .HasColumnType("text");

                    b.Property<double>("WindSpeed")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("WheatherColumnsEntitis");
                });
#pragma warning restore 612, 618
        }
    }
}
