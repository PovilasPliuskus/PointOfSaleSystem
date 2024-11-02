﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PointOfSaleSystem.API.Context;

#nullable disable

namespace PointOfSaleSystem.API.Migrations
{
    [DbContext(typeof(PointOfSaleSystemContext))]
    partial class PointOfSaleSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.CompanyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.CompanyProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("AlcoholicBeverage")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("fkCompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCompanyId");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("CompanyProduct");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.CompanyServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("fkCompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCompanyId");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("CompanyService");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LoginPasswordHashed")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("LoginUsername")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid>("fkEstablishmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkEstablishmentId");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EstablishmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("fkCompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCompanyId");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("Establishment");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EstablishmentProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("AmountInStock")
                        .HasColumnType("bigint");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid>("fkEstablishmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkEstablishmentId");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("EstablishmentProduct");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EstablishmentServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid>("fkEstablishmentId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkEstablishmentId");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("EstablishmentService");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.FullOrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("fkOrderId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("Tip")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id", "fkOrderId");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkModifiedByEmployee");

                    b.HasIndex("fkOrderId");

                    b.ToTable("FullOrder");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.OrderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("ReceiveTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("fkCreatedByEmployee")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkEstablishmentProduct")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkEstablishmentService")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("fkModifiedByEmployee")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("fkCreatedByEmployee");

                    b.HasIndex("fkEstablishmentProduct");

                    b.HasIndex("fkEstablishmentService");

                    b.HasIndex("fkModifiedByEmployee");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.CompanyEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.CompanyProductEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.CompanyEntity", "Company")
                        .WithMany("CompanyProducts")
                        .HasForeignKey("fkCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("Company");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.CompanyServiceEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.CompanyEntity", "Company")
                        .WithMany("CompanyServices")
                        .HasForeignKey("fkCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("Company");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EstablishmentEntity", "Establishment")
                        .WithMany("Employees")
                        .HasForeignKey("fkEstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("Establishment");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EstablishmentEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.CompanyEntity", "Company")
                        .WithMany("Establishments")
                        .HasForeignKey("fkCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("Company");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EstablishmentProductEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EstablishmentEntity", "Establishment")
                        .WithMany("EstablishmentProducts")
                        .HasForeignKey("fkEstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("Establishment");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EstablishmentServiceEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EstablishmentEntity", "Establishment")
                        .WithMany("EstablishmentServices")
                        .HasForeignKey("fkEstablishmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("Establishment");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.FullOrderEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.OrderEntity", "Order")
                        .WithMany()
                        .HasForeignKey("fkOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("Order");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.OrderEntity", b =>
                {
                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "CreatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkCreatedByEmployee");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EstablishmentProductEntity", "EstablishmentProduct")
                        .WithMany()
                        .HasForeignKey("fkEstablishmentProduct");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EstablishmentServiceEntity", "EstablishmentService")
                        .WithMany()
                        .HasForeignKey("fkEstablishmentService");

                    b.HasOne("PointOfSaleSystem.API.Models.Entities.EmployeeEntity", "UpdatedByEmployee")
                        .WithMany()
                        .HasForeignKey("fkModifiedByEmployee");

                    b.Navigation("CreatedByEmployee");

                    b.Navigation("EstablishmentProduct");

                    b.Navigation("EstablishmentService");

                    b.Navigation("UpdatedByEmployee");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.CompanyEntity", b =>
                {
                    b.Navigation("CompanyProducts");

                    b.Navigation("CompanyServices");

                    b.Navigation("Establishments");
                });

            modelBuilder.Entity("PointOfSaleSystem.API.Models.Entities.EstablishmentEntity", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("EstablishmentProducts");

                    b.Navigation("EstablishmentServices");
                });
#pragma warning restore 612, 618
        }
    }
}
