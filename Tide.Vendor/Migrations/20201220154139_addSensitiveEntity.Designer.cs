﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tide.Vendor;

namespace Tide.Vendor.Migrations
{
    [DbContext(typeof(VendorContext))]
    [Migration("20201220154139_addSensitiveEntity")]
    partial class addSensitiveEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Tide.Vendor.Models.Sensitive", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DLN")
                        .HasColumnType("TEXT");

                    b.Property<string>("PoliticalParty")
                        .HasColumnType("TEXT");

                    b.Property<string>("Religion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salary")
                        .HasColumnType("TEXT");

                    b.Property<string>("TFN")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Sensitives");
                });

            modelBuilder.Entity("Tide.Vendor.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Vuid")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tide.Vendor.Models.Sensitive", b =>
                {
                    b.HasOne("Tide.Vendor.Models.User", "User")
                        .WithOne("Sensitive")
                        .HasForeignKey("Tide.Vendor.Models.Sensitive", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
