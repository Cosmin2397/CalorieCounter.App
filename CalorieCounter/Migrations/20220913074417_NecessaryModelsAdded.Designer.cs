﻿// <auto-generated />
using System;
using CalorieCounter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalorieCounter.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220913074417_NecessaryModelsAdded")]
    partial class NecessaryModelsAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CalorieCounter.Dto.FoodToAdd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("FoodDashId")
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("MealTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ServingWeight")
                        .HasColumnType("int");

                    b.Property<int>("Servings")
                        .HasColumnType("int");

                    b.Property<double>("TotalCarbsFood")
                        .HasColumnType("float");

                    b.Property<double>("TotalFatsFood")
                        .HasColumnType("float");

                    b.Property<double>("TotalFibersFood")
                        .HasColumnType("float");

                    b.Property<double>("TotalKcalFood")
                        .HasColumnType("float");

                    b.Property<double>("TotalProteinFood")
                        .HasColumnType("float");

                    b.Property<double>("TotalWeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FoodDashId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodToAdd");
                });

            modelBuilder.Entity("CalorieCounter.Models.DayTotal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DayFoodsId")
                        .HasColumnType("int");

                    b.Property<int>("ExpectedValuesId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DayFoodsId");

                    b.HasIndex("ExpectedValuesId");

                    b.ToTable("DaysTotal");
                });

            modelBuilder.Entity("CalorieCounter.Models.Expected", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("ExpectedCarbs")
                        .HasColumnType("float");

                    b.Property<double>("ExpectedFats")
                        .HasColumnType("float");

                    b.Property<double>("ExpectedFibers")
                        .HasColumnType("float");

                    b.Property<double>("ExpectedKcal")
                        .HasColumnType("float");

                    b.Property<double>("ExpectedProtein")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Expecteds");
                });

            modelBuilder.Entity("CalorieCounter.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double>("Carbo")
                        .HasColumnType("float");

                    b.Property<double>("Fats")
                        .HasColumnType("float");

                    b.Property<double>("Fibers")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Protein")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("CalorieCounter.Models.FoodDash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<int>("Meal")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalCarbs")
                        .HasColumnType("float");

                    b.Property<double>("TotalFats")
                        .HasColumnType("float");

                    b.Property<double>("TotalFibers")
                        .HasColumnType("float");

                    b.Property<double>("TotalKcal")
                        .HasColumnType("float");

                    b.Property<double>("TotalMealKcal")
                        .HasColumnType("float");

                    b.Property<double>("TotalMealWeight")
                        .HasColumnType("float");

                    b.Property<double>("TotalProtein")
                        .HasColumnType("float");

                    b.Property<double>("TotalWeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FoodDashes");
                });

            modelBuilder.Entity("CalorieCounter.Dto.FoodToAdd", b =>
                {
                    b.HasOne("CalorieCounter.Models.FoodDash", null)
                        .WithMany("Foods")
                        .HasForeignKey("FoodDashId");

                    b.HasOne("CalorieCounter.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });

            modelBuilder.Entity("CalorieCounter.Models.DayTotal", b =>
                {
                    b.HasOne("CalorieCounter.Models.FoodDash", "DayFoods")
                        .WithMany()
                        .HasForeignKey("DayFoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalorieCounter.Models.Expected", "ExpectedValues")
                        .WithMany()
                        .HasForeignKey("ExpectedValuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DayFoods");

                    b.Navigation("ExpectedValues");
                });

            modelBuilder.Entity("CalorieCounter.Models.FoodDash", b =>
                {
                    b.Navigation("Foods");
                });
#pragma warning restore 612, 618
        }
    }
}
