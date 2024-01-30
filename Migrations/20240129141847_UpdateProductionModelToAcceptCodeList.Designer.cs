﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using controle_estoque.Data;

#nullable disable

namespace controle_estoque.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240129141847_UpdateProductionModelToAcceptCodeList")]
    partial class UpdateProductionModelToAcceptCodeList
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("controle_estoque.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FabricationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("MeasureType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<int>("ValidityTime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("controle_estoque.Models.Production", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<double>("AmountRecipes")
                        .HasColumnType("REAL");

                    b.Property<int>("Code")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductCodes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RecipeCode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Productions");
                });
#pragma warning restore 612, 618
        }
    }
}
