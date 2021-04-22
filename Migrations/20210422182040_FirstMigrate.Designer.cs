﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SummerDrinks.Models;

namespace SummerDrinks.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210422182040_FirstMigrate")]
    partial class FirstMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SummerDrinks.Models.Drink", b =>
                {
                    b.Property<int>("DrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Ice")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("IngredientFive")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IngredientFour")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IngredientOne")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IngredientThree")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("IngredientTwo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Liquor")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DrinkId");

                    b.HasIndex("UserId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("SummerDrinks.Models.FavoriteDrink", b =>
                {
                    b.Property<int>("FavoriteDrinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DrinkId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FavoriteDrinkId");

                    b.HasIndex("DrinkId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteDrinks");
                });

            modelBuilder.Entity("SummerDrinks.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SummerDrinks.Models.Drink", b =>
                {
                    b.HasOne("SummerDrinks.Models.User", "Creator")
                        .WithMany("CreatedDrinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SummerDrinks.Models.FavoriteDrink", b =>
                {
                    b.HasOne("SummerDrinks.Models.Drink", "Drink")
                        .WithMany("FavoriteDrinkList")
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SummerDrinks.Models.User", "User")
                        .WithMany("FavoriteDrinkList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
