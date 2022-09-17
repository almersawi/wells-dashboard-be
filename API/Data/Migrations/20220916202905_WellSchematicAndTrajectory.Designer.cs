﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220916202905_WellSchematicAndTrajectory")]
    partial class WellSchematicAndTrajectory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<float>("Azi")
                        .HasColumnType("real");

                    b.Property<float>("East")
                        .HasColumnType("real");

                    b.Property<float>("Inc")
                        .HasColumnType("real");

                    b.Property<float>("Md")
                        .HasColumnType("real");

                    b.Property<float>("North")
                        .HasColumnType("real");

                    b.Property<float>("Tvd")
                        .HasColumnType("real");

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

                    b.Property<float>("ChokeSize")
                        .HasColumnType("real");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<float>("Lon")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wells");
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
                    b.Navigation("Schematic");

                    b.Navigation("Trajectory");
                });
#pragma warning restore 612, 618
        }
    }
}