﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RoutePlanning.Infrastructure.Database;

#nullable disable

namespace RoutePlanning.Infrastructure.Migrations
{
    [DbContext(typeof(RoutePlanningDatabaseContext))]
    [Migration("20231109192121_OrderCreate")]
    partial class OrderCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RoutePlanning.Domain.Locations.Connection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DestinationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SourceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("SourceId");

                    b.ToTable("Connection");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Locations.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FromLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ToLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FromLocationId");

                    b.HasIndex("ToLocationId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Packages.Package", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("OrderId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Packages.PackageType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Fee")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PackageType");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Packages.PackageTypePackage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PackageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PackageId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PackageTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.HasIndex("PackageId1");

                    b.HasIndex("PackageTypeId");

                    b.HasIndex("TypeId");

                    b.ToTable("PackageTypePackage");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Locations.Connection", b =>
                {
                    b.HasOne("RoutePlanning.Domain.Locations.Location", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoutePlanning.Domain.Locations.Location", "Source")
                        .WithMany("Connections")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("RoutePlanning.Domain.Locations.Distance", "Distance", b1 =>
                        {
                            b1.Property<Guid>("ConnectionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int");

                            b1.HasKey("ConnectionId");

                            b1.ToTable("Connection");

                            b1.WithOwner()
                                .HasForeignKey("ConnectionId");
                        });

                    b.Navigation("Destination");

                    b.Navigation("Distance")
                        .IsRequired();

                    b.Navigation("Source");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Orders.Order", b =>
                {
                    b.HasOne("RoutePlanning.Domain.Locations.Location", "FromLocation")
                        .WithMany()
                        .HasForeignKey("FromLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoutePlanning.Domain.Locations.Location", "ToLocation")
                        .WithMany()
                        .HasForeignKey("ToLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromLocation");

                    b.Navigation("ToLocation");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Packages.Package", b =>
                {
                    b.HasOne("RoutePlanning.Domain.Orders.Order", "Order")
                        .WithOne("Package")
                        .HasForeignKey("RoutePlanning.Domain.Packages.Package", "OrderId")
                        .HasPrincipalKey("RoutePlanning.Domain.Orders.Order", "PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Packages.PackageTypePackage", b =>
                {
                    b.HasOne("RoutePlanning.Domain.Packages.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RoutePlanning.Domain.Packages.Package", null)
                        .WithMany("PackageTypePackages")
                        .HasForeignKey("PackageId1");

                    b.HasOne("RoutePlanning.Domain.Packages.PackageType", null)
                        .WithMany("PackageTypePackages")
                        .HasForeignKey("PackageTypeId");

                    b.HasOne("RoutePlanning.Domain.Packages.PackageType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Locations.Location", b =>
                {
                    b.Navigation("Connections");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Orders.Order", b =>
                {
                    b.Navigation("Package")
                        .IsRequired();
                });

            modelBuilder.Entity("RoutePlanning.Domain.Packages.Package", b =>
                {
                    b.Navigation("PackageTypePackages");
                });

            modelBuilder.Entity("RoutePlanning.Domain.Packages.PackageType", b =>
                {
                    b.Navigation("PackageTypePackages");
                });
#pragma warning restore 612, 618
        }
    }
}
