﻿// <auto-generated />
using System;
using ElectroHub.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectroHub.Infrastructure.Migrations
{
    [DbContext(typeof(ElectroHubDbContext))]
    [Migration("20241114175947_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectroHub.Domain.ChargePoint.ChargePoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChargingHubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SpotNumber")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("ChargingHubId");

                    b.ToTable("ChargePoints");
                });

            modelBuilder.Entity("ElectroHub.Domain.ChargePoint.ChargePointReservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ChargePointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ChargePointId");

                    b.ToTable("ChargePointReservations");
                });

            modelBuilder.Entity("ElectroHub.Domain.ChargePoint.ChargingHub", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ChargingHubs");
                });

            modelBuilder.Entity("ElectroHub.Domain.ChargePoint.ChargePoint", b =>
                {
                    b.HasOne("ElectroHub.Domain.ChargePoint.ChargingHub", "ChargingHub")
                        .WithMany("ChargePoints")
                        .HasForeignKey("ChargingHubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChargingHub");
                });

            modelBuilder.Entity("ElectroHub.Domain.ChargePoint.ChargePointReservation", b =>
                {
                    b.HasOne("ElectroHub.Domain.ChargePoint.ChargePoint", "ChargePoint")
                        .WithMany("ChargePointReservations")
                        .HasForeignKey("ChargePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ElectroHub.Domain.ChargePoint.User", "User", b1 =>
                        {
                            b1.Property<Guid>("ChargePointReservationId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UserId");

                            b1.HasKey("ChargePointReservationId");

                            b1.ToTable("ChargePointReservations");

                            b1.WithOwner()
                                .HasForeignKey("ChargePointReservationId");
                        });

                    b.Navigation("ChargePoint");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("ElectroHub.Domain.ChargePoint.ChargePoint", b =>
                {
                    b.Navigation("ChargePointReservations");
                });

            modelBuilder.Entity("ElectroHub.Domain.ChargePoint.ChargingHub", b =>
                {
                    b.Navigation("ChargePoints");
                });
#pragma warning restore 612, 618
        }
    }
}