﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopAPI.Models;

#nullable disable

namespace ShopAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221211071702_UpdateDatabase")]
    partial class UpdateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShopAPI.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"), 1L, 1);

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("ShopAPI.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("ShopAPI.Models.Collection", b =>
                {
                    b.Property<int>("CollectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("CollectionId");

                    b.ToTable("collection");
                });

            modelBuilder.Entity("ShopAPI.Models.Color", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"), 1L, 1);

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorId");

                    b.ToTable("color");
                });

            modelBuilder.Entity("ShopAPI.Models.ColorProduct", b =>
                {
                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ColorId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("colorProduct");
                });

            modelBuilder.Entity("ShopAPI.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CouponId"), 1L, 1);

                    b.Property<float>("Cost")
                        .HasColumnType("real");

                    b.Property<DateTime>("Exp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CouponId");

                    b.ToTable("coupon");
                });

            modelBuilder.Entity("ShopAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("CollectionId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ColorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quatity")
                        .HasColumnType("int");

                    b.Property<int?>("SizeId")
                        .HasColumnType("int");

                    b.Property<string>("Variety")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("ColorId");

                    b.HasIndex("SizeId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("ShopAPI.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeId"), 1L, 1);

                    b.Property<int>("CouponId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecipeDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("recipe");
                });

            modelBuilder.Entity("ShopAPI.Models.RecipeItem", b =>
                {
                    b.Property<int>("RecipeItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecipeItemId"), 1L, 1);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quatity")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("RecipeItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RecipeId");

                    b.ToTable("recipeItem");
                });

            modelBuilder.Entity("ShopAPI.Models.Size", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"), 1L, 1);

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SizeId");

                    b.ToTable("size");
                });

            modelBuilder.Entity("ShopAPI.Models.SizeProduct", b =>
                {
                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("SizeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("sizeProduct");
                });

            modelBuilder.Entity("ShopAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("ShopAPI.Models.Address", b =>
                {
                    b.HasOne("ShopAPI.Models.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShopAPI.Models.ColorProduct", b =>
                {
                    b.HasOne("ShopAPI.Models.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopAPI.Models.Product", "Product")
                        .WithMany("ColorProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopAPI.Models.Product", b =>
                {
                    b.HasOne("ShopAPI.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopAPI.Models.Collection", "Collection")
                        .WithMany("Products")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopAPI.Models.Color", null)
                        .WithMany("Products")
                        .HasForeignKey("ColorId");

                    b.HasOne("ShopAPI.Models.Size", null)
                        .WithMany("Products")
                        .HasForeignKey("SizeId");

                    b.Navigation("Category");

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("ShopAPI.Models.Recipe", b =>
                {
                    b.HasOne("ShopAPI.Models.Coupon", "Coupon")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopAPI.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coupon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ShopAPI.Models.RecipeItem", b =>
                {
                    b.HasOne("ShopAPI.Models.Product", "Product")
                        .WithMany("RecipeItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopAPI.Models.Recipe", "Recipe")
                        .WithMany("RecipeItems")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ShopAPI.Models.SizeProduct", b =>
                {
                    b.HasOne("ShopAPI.Models.Product", "Product")
                        .WithMany("SizeProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopAPI.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("ShopAPI.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopAPI.Models.Collection", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopAPI.Models.Color", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopAPI.Models.Coupon", b =>
                {
                    b.Navigation("Recipes");
                });

            modelBuilder.Entity("ShopAPI.Models.Product", b =>
                {
                    b.Navigation("ColorProducts");

                    b.Navigation("RecipeItems");

                    b.Navigation("SizeProducts");
                });

            modelBuilder.Entity("ShopAPI.Models.Recipe", b =>
                {
                    b.Navigation("RecipeItems");
                });

            modelBuilder.Entity("ShopAPI.Models.Size", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ShopAPI.Models.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
