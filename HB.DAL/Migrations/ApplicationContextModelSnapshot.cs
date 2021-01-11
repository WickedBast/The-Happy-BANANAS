﻿// <auto-generated />
using System;
using HB.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HB.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HB.Entity.Application.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CommentText")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("RateGiven")
                        .HasColumnType("decimal(18,1)");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("ReservationID")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoomNumber")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("ReservationID");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("HB.Entity.Application.ExtraService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Hour")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NumberOfPerson")
                        .HasColumnType("int");

                    b.Property<string>("PNRNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Quota")
                        .HasColumnType("int");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<string>("ServiceType")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("ExtraService");
                });

            modelBuilder.Entity("HB.Entity.Application.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Night")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPerson")
                        .HasColumnType("int");

                    b.Property<string>("PNRNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<decimal>("RateAVG")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoomNumber")
                        .HasColumnType("char(36)");

                    b.Property<string>("Slug")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserID");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("HB.Entity.Application.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsFull")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("PersonCapacity")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("HB.Entity.Application.RoomImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomID")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomImage");
                });

            modelBuilder.Entity("HB.Entity.Application.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RecordStatus")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HB.Entity.Application.Comment", b =>
                {
                    b.HasOne("HB.Entity.Application.Reservation", "Reservation")
                        .WithMany("Comments")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HB.Entity.Application.Room", "Room")
                        .WithMany("Comments")
                        .HasForeignKey("RoomId");

                    b.HasOne("HB.Entity.Application.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HB.Entity.Application.ExtraService", b =>
                {
                    b.HasOne("HB.Entity.Application.User", "User")
                        .WithMany("ExtraServices")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HB.Entity.Application.Reservation", b =>
                {
                    b.HasOne("HB.Entity.Application.Room", "Room")
                        .WithMany("Reservations")
                        .HasForeignKey("RoomId");

                    b.HasOne("HB.Entity.Application.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HB.Entity.Application.RoomImage", b =>
                {
                    b.HasOne("HB.Entity.Application.Room", "Room")
                        .WithMany("RoomImages")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
