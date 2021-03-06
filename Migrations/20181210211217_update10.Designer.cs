﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nucleocs.Data;

namespace nucleocs.Migrations
{
    [DbContext(typeof(NucleoContext))]
    [Migration("20181210211217_update10")]
    partial class update10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nucleocs.Models.Aggregation", b =>
                {
                    b.Property<int>("ProductFatherId");

                    b.Property<int>("ProductSonId");

                    b.Property<int?>("ProductSProductId");

                    b.Property<int>("Quantity");

                    b.Property<bool>("Required");

                    b.HasKey("ProductFatherId", "ProductSonId");

                    b.HasIndex("ProductSProductId");

                    b.ToTable("Aggregations");
                });

            modelBuilder.Entity("nucleocs.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("SuperCategoryId");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("nucleocs.Models.Finishing", b =>
                {
                    b.Property<int>("FinishingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("FinishingId");

                    b.ToTable("Finishings");
                });

            modelBuilder.Entity("nucleocs.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("MaterialId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("nucleocs.Models.MaterialFinishing", b =>
                {
                    b.Property<int>("MaterialId");

                    b.Property<int>("FinishingId");

                    b.HasKey("MaterialId", "FinishingId");

                    b.HasIndex("FinishingId");

                    b.ToTable("MaterialFinishings");
                });

            modelBuilder.Entity("nucleocs.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<double>("DepthMax");

                    b.Property<double>("DepthMin");

                    b.Property<int>("DimensionType");

                    b.Property<double>("HeightMax");

                    b.Property<double>("HeightMin");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<double>("Weight");

                    b.Property<double>("WidthMax");

                    b.Property<double>("WidthMin");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("nucleocs.Models.ProductMaterial", b =>
                {
                    b.Property<int>("ProductId");

                    b.Property<int>("MaterialId");

                    b.HasKey("ProductId", "MaterialId");

                    b.HasIndex("MaterialId");

                    b.ToTable("ProductMaterials");
                });

            modelBuilder.Entity("nucleocs.Models.Restriction", b =>
                {
                    b.Property<int>("RestrictionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AggregationProductFatherId");

                    b.Property<int?>("AggregationProductSonId");

                    b.Property<int?>("Algoritmid");

                    b.Property<int>("ObjectToAlgoritm");

                    b.HasKey("RestrictionId");

                    b.HasIndex("Algoritmid");

                    b.HasIndex("AggregationProductFatherId", "AggregationProductSonId");

                    b.ToTable("Restrictions");
                });

            modelBuilder.Entity("nucleocs.Models.Strategy.AlgoritmStrategy", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Algoritms");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AlgoritmStrategy");
                });

            modelBuilder.Entity("nucleocs.Models.Strategy.DimensionAlgoritm", b =>
                {
                    b.HasBaseType("nucleocs.Models.Strategy.AlgoritmStrategy");


                    b.ToTable("DimensionAlgoritm");

                    b.HasDiscriminator().HasValue("DimensionAlgoritm");
                });

            modelBuilder.Entity("nucleocs.Models.Strategy.MaterialAlgoritm", b =>
                {
                    b.HasBaseType("nucleocs.Models.Strategy.AlgoritmStrategy");


                    b.ToTable("MaterialAlgoritm");

                    b.HasDiscriminator().HasValue("MaterialAlgoritm");
                });

            modelBuilder.Entity("nucleocs.Models.Strategy.OccupationAlgoritm", b =>
                {
                    b.HasBaseType("nucleocs.Models.Strategy.AlgoritmStrategy");

                    b.Property<double>("Max");

                    b.Property<double>("Min");

                    b.ToTable("OccupationAlgoritm");

                    b.HasDiscriminator().HasValue("OccupationAlgoritm");
                });

            modelBuilder.Entity("nucleocs.Models.Aggregation", b =>
                {
                    b.HasOne("nucleocs.Models.Product", "ProductF")
                        .WithMany("ProdSon")
                        .HasForeignKey("ProductFatherId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("nucleocs.Models.Product", "ProductS")
                        .WithMany()
                        .HasForeignKey("ProductSProductId");
                });

            modelBuilder.Entity("nucleocs.Models.MaterialFinishing", b =>
                {
                    b.HasOne("nucleocs.Models.Finishing", "Finishing")
                        .WithMany("MaterialFinishings")
                        .HasForeignKey("FinishingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("nucleocs.Models.Material", "Material")
                        .WithMany("MaterialFinishings")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("nucleocs.Models.Product", b =>
                {
                    b.HasOne("nucleocs.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("nucleocs.Models.ProductMaterial", b =>
                {
                    b.HasOne("nucleocs.Models.Material", "Material")
                        .WithMany("ProductMaterials")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("nucleocs.Models.Product", "Product")
                        .WithMany("ProductMaterials")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("nucleocs.Models.Restriction", b =>
                {
                    b.HasOne("nucleocs.Models.Strategy.AlgoritmStrategy", "Algoritm")
                        .WithMany()
                        .HasForeignKey("Algoritmid");

                    b.HasOne("nucleocs.Models.Aggregation", "Aggregation")
                        .WithMany("Restrictions")
                        .HasForeignKey("AggregationProductFatherId", "AggregationProductSonId");
                });
#pragma warning restore 612, 618
        }
    }
}
