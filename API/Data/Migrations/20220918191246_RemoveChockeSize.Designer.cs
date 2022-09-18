﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220918191246_RemoveChockeSize")]
    partial class RemoveChockeSize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.Entities.ProductionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("WellId")
                        .HasColumnType("int");

                    b.Property<double>("WellheadPressure")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("WellId");

                    b.ToTable("Production_Data");
                });

            modelBuilder.Entity("API.Entities.Schematic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Bottom")
                        .HasColumnType("real");

                    b.Property<float>("OD")
                        .HasColumnType("real");

                    b.Property<float>("TOC")
                        .HasColumnType("real");

                    b.Property<float>("Top")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WellId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WellId");

                    b.ToTable("Well_Schematic");
                });

            modelBuilder.Entity("API.Entities.Trajectory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Azi")
                        .HasColumnType("float");

                    b.Property<double>("East")
                        .HasColumnType("float");

                    b.Property<double>("Inc")
                        .HasColumnType("float");

                    b.Property<double>("Md")
                        .HasColumnType("float");

                    b.Property<double>("North")
                        .HasColumnType("float");

                    b.Property<double>("Tvd")
                        .HasColumnType("float");

                    b.Property<int>("WellId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WellId");

                    b.ToTable("Well_Trajectory");
                });

            modelBuilder.Entity("API.Entities.Well", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wells");
                });

            modelBuilder.Entity("API.Views.DashboardView", b =>
                {
                    b.Property<int>("AbandonedWellCount")
                        .HasColumnType("int");

                    b.Property<double>("CurrentRate")
                        .HasColumnType("float");

                    b.Property<string>("CurrentRateDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DualStringWellCount")
                        .HasColumnType("int");

                    b.Property<int>("FlowingWellCount")
                        .HasColumnType("int");

                    b.Property<int>("InjectorWellCount")
                        .HasColumnType("int");

                    b.Property<double>("MaxDailyRate")
                        .HasColumnType("float");

                    b.Property<string>("MaxDailyRateDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MaxWellCurrentRate")
                        .HasColumnType("float");

                    b.Property<double>("MinDailyRate")
                        .HasColumnType("float");

                    b.Property<string>("MinDailyRateDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProducerWellCount")
                        .HasColumnType("int");

                    b.Property<int>("ShutinWellCount")
                        .HasColumnType("int");

                    b.Property<int>("SingleStringWellCount")
                        .HasColumnType("int");

                    b.Property<string>("WellWithMaxCurrentRate")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("Dashboard_View");
                });

            modelBuilder.Entity("API.Views.WellSummaryView", b =>
                {
                    b.Property<double?>("AvgProdRate")
                        .HasColumnType("float");

                    b.Property<double?>("AvgWhPressure")
                        .HasColumnType("float");

                    b.Property<double?>("LastEast")
                        .HasColumnType("float");

                    b.Property<double?>("LastNorth")
                        .HasColumnType("float");

                    b.Property<DateTime?>("LastProdDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("LastProdRate")
                        .HasColumnType("float");

                    b.Property<double?>("LastTvd")
                        .HasColumnType("float");

                    b.Property<double?>("LastWhPressure")
                        .HasColumnType("float");

                    b.Property<DateTime?>("LastWhPressureDate")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Lat")
                        .HasColumnType("real");

                    b.Property<float?>("Lon")
                        .HasColumnType("real");

                    b.Property<double?>("MaxProdRate")
                        .HasColumnType("float");

                    b.Property<float?>("MaxSchematicBottom")
                        .HasColumnType("real");

                    b.Property<double?>("MaxWhPressure")
                        .HasColumnType("float");

                    b.Property<double?>("MinProdRate")
                        .HasColumnType("float");

                    b.Property<double?>("MinWhPressure")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WellId")
                        .HasColumnType("int");

                    b.ToView("Well_Summary_view");
                });

            modelBuilder.Entity("API.Entities.ProductionData", b =>
                {
                    b.HasOne("API.Entities.Well", "Well")
                        .WithMany("ProductionData")
                        .HasForeignKey("WellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Well");
                });

            modelBuilder.Entity("API.Entities.Schematic", b =>
                {
                    b.HasOne("API.Entities.Well", "Well")
                        .WithMany("Schematic")
                        .HasForeignKey("WellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Well");
                });

            modelBuilder.Entity("API.Entities.Trajectory", b =>
                {
                    b.HasOne("API.Entities.Well", "Well")
                        .WithMany("Trajectory")
                        .HasForeignKey("WellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Well");
                });

            modelBuilder.Entity("API.Entities.Well", b =>
                {
                    b.Navigation("ProductionData");

                    b.Navigation("Schematic");

                    b.Navigation("Trajectory");
                });
#pragma warning restore 612, 618
        }
    }
}
