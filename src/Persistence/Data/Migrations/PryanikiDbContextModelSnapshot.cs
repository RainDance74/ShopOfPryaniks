﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopOfPryaniks.Persistence.Data;

#nullable disable

namespace ShopOfPryaniks.Persistence.Data.Migrations
{
    [DbContext(typeof(PryanikiDbContext))]
    partial class PryanikiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopOfPryaniks.Domain.Common.BasePosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("discriminator");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer")
                        .HasColumnName("product_id");

                    b.HasKey("Id")
                        .HasName("pk_positions");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_positions_product_id");

                    b.ToTable("positions", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("BasePosition");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.HasKey("Id")
                        .HasName("pk_carts");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_carts_owner_id");

                    b.ToTable("carts", (string)null);
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_customer");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_employee");

                    b.ToTable("employee", (string)null);
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer")
                        .HasColumnName("owner_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_orders_owner_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Discount")
                        .HasColumnType("integer")
                        .HasColumnName("discount");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.ToTable("products", (string)null);
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.CartPosition", b =>
                {
                    b.HasBaseType("ShopOfPryaniks.Domain.Common.BasePosition");

                    b.Property<int?>("CartId")
                        .HasColumnType("integer")
                        .HasColumnName("cart_id");

                    b.HasIndex("CartId")
                        .HasDatabaseName("ix_positions_cart_id");

                    b.ToTable("positions", (string)null);

                    b.HasDiscriminator().HasValue("CartPosition");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.OrderPosition", b =>
                {
                    b.HasBaseType("ShopOfPryaniks.Domain.Common.BasePosition");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_positions_order_id");

                    b.ToTable("positions", (string)null);

                    b.HasDiscriminator().HasValue("OrderPosition");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Common.BasePosition", b =>
                {
                    b.HasOne("ShopOfPryaniks.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_positions_products_product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Cart", b =>
                {
                    b.HasOne("ShopOfPryaniks.Domain.Entities.Customer", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_carts_customer_owner_id");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Order", b =>
                {
                    b.HasOne("ShopOfPryaniks.Domain.Entities.Customer", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_customer_owner_id");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.CartPosition", b =>
                {
                    b.HasOne("ShopOfPryaniks.Domain.Entities.Cart", null)
                        .WithMany("Positions")
                        .HasForeignKey("CartId")
                        .HasConstraintName("fk_positions_carts_cart_id");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.OrderPosition", b =>
                {
                    b.HasOne("ShopOfPryaniks.Domain.Entities.Order", null)
                        .WithMany("Positions")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_positions_orders_order_id");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Cart", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("ShopOfPryaniks.Domain.Entities.Order", b =>
                {
                    b.Navigation("Positions");
                });
#pragma warning restore 612, 618
        }
    }
}
