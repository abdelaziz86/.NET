﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    [DbContext(typeof(AmContext))]
    [Migration("20230306110825_TPT1")]
    partial class TPT1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AM.ApplicationCore.Domain.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("EffectiveArrival")
                        .HasColumnType("date");

                    b.Property<float>("EstimatedDuration")
                        .HasColumnType("real");

                    b.Property<DateTime>("FlightDate")
                        .HasColumnType("date");

                    b.Property<int?>("PlaneFk")
                        .HasColumnType("int");

                    b.HasKey("FlightId");

                    b.HasIndex("PlaneFk");

                    b.ToTable("Vols", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Passenger", b =>
                {
                    b.Property<int>("PassportNumber")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassportNumber"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<string>("TelNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.HasKey("PassportNumber");

                    b.ToTable("Passenger", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Plane", b =>
                {
                    b.Property<int>("PlaneKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlaneKey"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("PlaneCapacity");

                    b.Property<DateTime>("ManufactureDate")
                        .HasColumnType("date");

                    b.Property<int>("PlaneType")
                        .HasColumnType("int");

                    b.HasKey("PlaneKey");

                    b.ToTable("MyPlane", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Ticket", b =>
                {
                    b.Property<int>("FlightFk")
                        .HasColumnType("int");

                    b.Property<int>("PassengerFk")
                        .HasColumnType("int");

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerPassportNumber")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasPrecision(3, 2)
                        .HasColumnType("float(3)");

                    b.Property<string>("Siege")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<bool>("VIP")
                        .HasColumnType("bit");

                    b.HasKey("FlightFk", "PassengerFk");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerPassportNumber");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Staff", b =>
                {
                    b.HasBaseType("AM.ApplicationCore.Domain.Passenger");

                    b.Property<DateTime>("EmployementDate")
                        .HasColumnType("date");

                    b.Property<float>("Salary")
                        .HasColumnType("real");

                    b.Property<string>("function")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.ToTable("Staff", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Traveller", b =>
                {
                    b.HasBaseType("AM.ApplicationCore.Domain.Passenger");

                    b.Property<string>("HealthInformation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar");

                    b.ToTable("Traveller", (string)null);
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Flight", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Plane", "Plane")
                        .WithMany("Flights")
                        .HasForeignKey("PlaneFk")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Passenger", b =>
                {
                    b.OwnsOne("AM.ApplicationCore.Domain.FullName", "FullName", b1 =>
                        {
                            b1.Property<int>("PassengerPassportNumber")
                                .HasColumnType("int");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar")
                                .HasColumnName("PassFirstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar")
                                .HasColumnName("PassLastName");

                            b1.HasKey("PassengerPassportNumber");

                            b1.ToTable("Passenger");

                            b1.WithOwner()
                                .HasForeignKey("PassengerPassportNumber");
                        });

                    b.Navigation("FullName")
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Ticket", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Flight", "Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.ApplicationCore.Domain.Passenger", "Passenger")
                        .WithMany("Tickets")
                        .HasForeignKey("PassengerPassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Staff", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.ApplicationCore.Domain.Staff", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Traveller", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Passenger", null)
                        .WithOne()
                        .HasForeignKey("AM.ApplicationCore.Domain.Traveller", "PassportNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Flight", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Passenger", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Plane", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
