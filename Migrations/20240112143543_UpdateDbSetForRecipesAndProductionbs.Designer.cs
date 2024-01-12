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
    [Migration("20240112143543_UpdateDbSetForRecipesAndProductionbs")]
    partial class UpdateDbSetForRecipesAndProductionbs
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

                    b.Property<bool>("Ingredient")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MeasureType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("RecipeId")
                        .HasColumnType("TEXT");

                    b.Property<int>("ValidityTime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

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

                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ProductionDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("controle_estoque.Models.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("controle_estoque.Models.Product", b =>
                {
                    b.HasOne("controle_estoque.Models.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId");
                });

            modelBuilder.Entity("controle_estoque.Models.Production", b =>
                {
                    b.HasOne("controle_estoque.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("controle_estoque.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("controle_estoque.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });
#pragma warning restore 612, 618
        }
    }
}
