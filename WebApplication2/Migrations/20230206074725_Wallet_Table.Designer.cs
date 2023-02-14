﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Models;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230206074725_Wallet_Table")]
    partial class WalletTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.Coin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Walletid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Walletid");

                    b.ToTable("coins");
                });

            modelBuilder.Entity("WebApplication2.Models.Wallet", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<float>("balance")
                        .HasColumnType("real");

                    b.Property<DateTime>("last_update")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("wallets");
                });

            modelBuilder.Entity("WebApplication2.Models.Coin", b =>
                {
                    b.HasOne("WebApplication2.Models.Wallet", null)
                        .WithMany("coins")
                        .HasForeignKey("Walletid");
                });

            modelBuilder.Entity("WebApplication2.Models.Wallet", b =>
                {
                    b.Navigation("coins");
                });
#pragma warning restore 612, 618
        }
    }
}
