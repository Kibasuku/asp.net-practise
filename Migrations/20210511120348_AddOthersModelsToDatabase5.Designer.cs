﻿// <auto-generated />
using System;
using Accounting.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Accounting.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210511120348_AddOthersModelsToDatabase5")]
    partial class AddOthersModelsToDatabase5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Accounting.Models.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Accounting.Models.Goods", b =>
                {
                    b.Property<int>("goodsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<int>("goodsCost")
                        .HasColumnType("int");

                    b.Property<string>("goodsName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("orderId")
                        .HasColumnType("int");

                    b.Property<int>("storageId")
                        .HasColumnType("int");

                    b.HasKey("goodsId");

                    b.HasIndex("categoryId");

                    b.HasIndex("orderId");

                    b.HasIndex("storageId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Accounting.Models.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("goodsId")
                        .HasColumnType("int");

                    b.Property<string>("orderTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("orderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Accounting.Models.Storage", b =>
                {
                    b.Property<int>("storageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("storageAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("storageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("storageId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Accounting.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Accounting.Models.Goods", b =>
                {
                    b.HasOne("Accounting.Models.Category", "Category")
                        .WithMany("Goods")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Accounting.Models.Order", null)
                        .WithMany("Goods")
                        .HasForeignKey("orderId");

                    b.HasOne("Accounting.Models.Storage", "Storage")
                        .WithMany("Goods")
                        .HasForeignKey("storageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Accounting.Models.Category", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Accounting.Models.Order", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Accounting.Models.Storage", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}
