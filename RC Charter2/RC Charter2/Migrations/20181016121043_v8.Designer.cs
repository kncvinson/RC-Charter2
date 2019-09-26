﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RC_Charter2.Models;

namespace RC_Charter2.Migrations
{
    [DbContext(typeof(RC_Charter2Context))]
    [Migration("20181016121043_v8")]
    partial class v8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RC_Charter2.Models.Aircraft", b =>
                {
                    b.Property<int?>("AircraftNumber")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftPropertiesId");

                    b.Property<decimal?>("ChargePerMile")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("money");

                    b.Property<decimal?>("HourlyWaitingCharge")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("money");

                    b.Property<string>("Model");

                    b.Property<int?>("NumberOfSeats");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.Property<int?>("YearManufactured");

                    b.HasKey("AircraftNumber");

                    b.HasIndex("AircraftPropertiesId");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("RC_Charter2.Models.AircraftProperties", b =>
                {
                    b.Property<int?>("AircraftPropertiesId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AircraftCategory");

                    b.Property<string>("AircraftType");

                    b.Property<string>("AircraftWeight");

                    b.Property<string>("EngineType");

                    b.HasKey("AircraftPropertiesId");

                    b.ToTable("AircraftProperty");
                });

            modelBuilder.Entity("RC_Charter2.Models.BalanceHistory", b =>
                {
                    b.Property<int?>("BalanceHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharterTripId");

                    b.Property<DateTime?>("DatePaid")
                        .HasColumnType("date");

                    b.Property<string>("ModeOfPayment");

                    b.Property<decimal?>("RemainingBalance")
                        .HasColumnType("money");

                    b.HasKey("BalanceHistoryId");

                    b.HasIndex("CharterTripId");

                    b.ToTable("BalanceHistory");
                });

            modelBuilder.Entity("RC_Charter2.Models.Cash", b =>
                {
                    b.Property<int?>("CashId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("PaymentModeId");

                    b.HasKey("CashId");

                    b.ToTable("Cash");
                });

            modelBuilder.Entity("RC_Charter2.Models.CharterFlightCharge", b =>
                {
                    b.Property<int?>("CharterFlightChargeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("ChargeType");

                    b.Property<int?>("CharterTripId");

                    b.Property<int?>("EmployeeId");

                    b.Property<double?>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("CharterFlightChargeId");

                    b.HasIndex("CharterTripId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CharterFlightCharge");
                });

            modelBuilder.Entity("RC_Charter2.Models.CharterTrip", b =>
                {
                    b.Property<int?>("CharterTripId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftNumber");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime?>("DateLastPaid")
                        .HasColumnType("date");

                    b.Property<string>("FinalDestination");

                    b.Property<string>("Origin");

                    b.Property<string>("Purpose");

                    b.Property<decimal?>("RemainingBalance")
                        .HasColumnType("money");

                    b.Property<decimal?>("TotalCharge")
                        .HasColumnType("money");

                    b.Property<double?>("TotalDistanceFlown")
                        .HasColumnType("float");

                    b.Property<double?>("TotalFuelUsage")
                        .HasColumnType("float");

                    b.Property<double?>("TotalWaitingTime")
                        .HasColumnType("float");

                    b.HasKey("CharterTripId");

                    b.HasIndex("AircraftNumber");

                    b.HasIndex("CustomerId");

                    b.ToTable("CharterTrip");
                });

            modelBuilder.Entity("RC_Charter2.Models.Check", b =>
                {
                    b.Property<int?>("CheckId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("money");

                    b.Property<DateTime?>("CheckDate")
                        .HasColumnType("date");

                    b.Property<string>("CheckNumber");

                    b.Property<int?>("PaymentModeId");

                    b.HasKey("CheckId");

                    b.ToTable("Check");
                });

            modelBuilder.Entity("RC_Charter2.Models.CrewAssignment", b =>
                {
                    b.Property<int?>("CrewAssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharterTripId");

                    b.Property<DateTime?>("DateAssigned")
                        .HasColumnType("date");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("Role");

                    b.Property<double?>("WorkHours")
                        .HasColumnType("float");

                    b.HasKey("CrewAssignmentId");

                    b.HasIndex("CharterTripId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CrewAssignment");
                });

            modelBuilder.Entity("RC_Charter2.Models.CrewRequirement", b =>
                {
                    b.Property<int?>("CrewRequirementId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AircraftPropertiesId");

                    b.Property<string>("LicenseType");

                    b.Property<int?>("RequiredNumber");

                    b.HasKey("CrewRequirementId");

                    b.HasIndex("AircraftPropertiesId");

                    b.HasIndex("LicenseType");

                    b.ToTable("CrewRequirement");
                });

            modelBuilder.Entity("RC_Charter2.Models.Customer", b =>
                {
                    b.Property<int?>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<decimal?>("AvailableCredits")
                        .HasColumnType("money");

                    b.Property<string>("Name");

                    b.Property<decimal?>("UsedCredits")
                        .HasColumnType("money");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("RC_Charter2.Models.Employee", b =>
                {
                    b.Property<int?>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("RC_Charter2.Models.Flight", b =>
                {
                    b.Property<int?>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CharterTripId");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Destination");

                    b.Property<double?>("DistanceFlown")
                        .HasColumnType("float");

                    b.Property<double?>("FuelUsage")
                        .HasColumnType("float");

                    b.Property<int?>("Order");

                    b.Property<string>("Origin");

                    b.Property<DateTime?>("TimeArrival");

                    b.Property<DateTime?>("TimeDeparture");

                    b.Property<double?>("WaitingTime")
                        .HasColumnType("float");

                    b.HasKey("FlightId");

                    b.HasIndex("CharterTripId");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("RC_Charter2.Models.License", b =>
                {
                    b.Property<string>("LicenseType")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("LicenseType");

                    b.ToTable("License");
                });

            modelBuilder.Entity("RC_Charter2.Models.Licensure", b =>
                {
                    b.Property<int?>("LicensureId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateEarned")
                        .HasColumnType("date");

                    b.Property<int?>("EmployeeId");

                    b.Property<string>("LicenseType");

                    b.HasKey("LicensureId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LicenseType");

                    b.ToTable("Licensure");
                });

            modelBuilder.Entity("RC_Charter2.Models.PaymentMode", b =>
                {
                    b.Property<int?>("PaymentModeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CashId");

                    b.Property<int?>("CharterTripId");

                    b.Property<int?>("CheckId");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("ModeOfPayment");

                    b.HasKey("PaymentModeId");

                    b.HasIndex("CashId")
                        .IsUnique()
                        .HasFilter("[CashId] IS NOT NULL");

                    b.HasIndex("CharterTripId");

                    b.HasIndex("CheckId")
                        .IsUnique()
                        .HasFilter("[CheckId] IS NOT NULL");

                    b.HasIndex("CustomerId");

                    b.ToTable("PaymentMode");
                });

            modelBuilder.Entity("RC_Charter2.Models.Result", b =>
                {
                    b.Property<int?>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("date");

                    b.Property<string>("TestCode");

                    b.Property<DateTime?>("TestDate")
                        .HasColumnType("date");

                    b.Property<string>("TestResult");

                    b.HasKey("ResultId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TestCode");

                    b.ToTable("Result");
                });

            modelBuilder.Entity("RC_Charter2.Models.Test", b =>
                {
                    b.Property<string>("TestCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TestDescription");

                    b.Property<string>("TestFrequency");

                    b.HasKey("TestCode");

                    b.ToTable("Test");
                });

            modelBuilder.Entity("RC_Charter2.Models.Aircraft", b =>
                {
                    b.HasOne("RC_Charter2.Models.AircraftProperties", "AircraftProperties")
                        .WithMany("Aircraft")
                        .HasForeignKey("AircraftPropertiesId");
                });

            modelBuilder.Entity("RC_Charter2.Models.BalanceHistory", b =>
                {
                    b.HasOne("RC_Charter2.Models.CharterTrip", "CharterTrip")
                        .WithMany("BalanceHistories")
                        .HasForeignKey("CharterTripId");
                });

            modelBuilder.Entity("RC_Charter2.Models.CharterFlightCharge", b =>
                {
                    b.HasOne("RC_Charter2.Models.CharterTrip", "CharterTrip")
                        .WithMany("CharterFlightCharges")
                        .HasForeignKey("CharterTripId");

                    b.HasOne("RC_Charter2.Models.Employee", "Employee")
                        .WithMany("CharterFlightCharges")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("RC_Charter2.Models.CharterTrip", b =>
                {
                    b.HasOne("RC_Charter2.Models.Aircraft", "Aircraft")
                        .WithMany("CharterTrips")
                        .HasForeignKey("AircraftNumber");

                    b.HasOne("RC_Charter2.Models.Customer", "Customer")
                        .WithMany("CharterTrips")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("RC_Charter2.Models.CrewAssignment", b =>
                {
                    b.HasOne("RC_Charter2.Models.CharterTrip", "CharterTrip")
                        .WithMany("CrewAssignments")
                        .HasForeignKey("CharterTripId");

                    b.HasOne("RC_Charter2.Models.Employee", "Employee")
                        .WithMany("CrewAssignments")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("RC_Charter2.Models.CrewRequirement", b =>
                {
                    b.HasOne("RC_Charter2.Models.AircraftProperties", "AircraftProperties")
                        .WithMany("CrewRequirements")
                        .HasForeignKey("AircraftPropertiesId");

                    b.HasOne("RC_Charter2.Models.License", "License")
                        .WithMany("CrewRequirements")
                        .HasForeignKey("LicenseType");
                });

            modelBuilder.Entity("RC_Charter2.Models.Flight", b =>
                {
                    b.HasOne("RC_Charter2.Models.CharterTrip", "CharterTrip")
                        .WithMany("Flights")
                        .HasForeignKey("CharterTripId");
                });

            modelBuilder.Entity("RC_Charter2.Models.Licensure", b =>
                {
                    b.HasOne("RC_Charter2.Models.Employee", "Employee")
                        .WithMany("Licensures")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RC_Charter2.Models.License", "License")
                        .WithMany("Licensures")
                        .HasForeignKey("LicenseType");
                });

            modelBuilder.Entity("RC_Charter2.Models.PaymentMode", b =>
                {
                    b.HasOne("RC_Charter2.Models.Cash", "Cash")
                        .WithOne("PaymentMode")
                        .HasForeignKey("RC_Charter2.Models.PaymentMode", "CashId");

                    b.HasOne("RC_Charter2.Models.CharterTrip", "CharterTrip")
                        .WithMany("PaymentModes")
                        .HasForeignKey("CharterTripId");

                    b.HasOne("RC_Charter2.Models.Check", "Check")
                        .WithOne("PaymentMode")
                        .HasForeignKey("RC_Charter2.Models.PaymentMode", "CheckId");

                    b.HasOne("RC_Charter2.Models.Customer", "Customer")
                        .WithMany("PaymentModes")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("RC_Charter2.Models.Result", b =>
                {
                    b.HasOne("RC_Charter2.Models.Employee", "Employee")
                        .WithMany("Results")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RC_Charter2.Models.Test", "Test")
                        .WithMany("Results")
                        .HasForeignKey("TestCode");
                });
#pragma warning restore 612, 618
        }
    }
}
