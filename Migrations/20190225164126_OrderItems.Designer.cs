﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace webshopApi.Migrations
{
    [DbContext(typeof(webContextDb))]
    [Migration("20190225164126_OrderItems")]
    partial class OrderItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity("Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dateCreated");

                    b.Property<int>("userId");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("CartItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("cartId");

                    b.Property<int>("kolicina");

                    b.Property<int>("productId");

                    b.HasKey("Id");

                    b.HasIndex("cartId");

                    b.HasIndex("productId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("cartId");

                    b.Property<DateTime>("dateOrder");

                    b.Property<int>("userId");

                    b.HasKey("Id");

                    b.HasIndex("cartId");

                    b.HasIndex("userId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Msrp");

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<int>("brandId");

                    b.Property<int>("groupId");

                    b.Property<string>("picture")
                        .HasMaxLength(65535);

                    b.Property<decimal>("price");

                    b.HasKey("Id");

                    b.HasIndex("brandId");

                    b.HasIndex("groupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductDescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description")
                        .HasMaxLength(255);

                    b.Property<string>("descriptionName")
                        .HasMaxLength(255);

                    b.Property<int>("productId");

                    b.HasKey("Id");

                    b.HasIndex("productId");

                    b.ToTable("ProductDescriptions");
                });

            modelBuilder.Entity("ProductPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("idProd");

                    b.Property<string>("picture")
                        .HasMaxLength(65535);

                    b.HasKey("Id");

                    b.HasIndex("idProd");

                    b.ToTable("ProductPictures");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UsersInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdUser");

                    b.Property<string>("adresa")
                        .HasMaxLength(255);

                    b.Property<string>("brTelefona")
                        .HasMaxLength(255);

                    b.Property<string>("fName")
                        .HasMaxLength(255);

                    b.Property<string>("grad")
                        .HasMaxLength(255);

                    b.Property<string>("lName")
                        .HasMaxLength(255);

                    b.Property<int>("postalCode");

                    b.Property<string>("userName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("UsersInfo");
                });

            modelBuilder.Entity("Cart", b =>
                {
                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CartItems", b =>
                {
                    b.HasOne("Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Order", b =>
                {
                    b.HasOne("Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.HasOne("Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("brandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Group", "Group")
                        .WithMany()
                        .HasForeignKey("groupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductDescription", b =>
                {
                    b.HasOne("Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProductPicture", b =>
                {
                    b.HasOne("Product", "Product")
                        .WithMany()
                        .HasForeignKey("idProd")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("UsersInfo", b =>
                {
                    b.HasOne("User", "user")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
