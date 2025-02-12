﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SplitExpenseTracker.Data;

#nullable disable

namespace SplitExpenseTracker.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250207103140_initialcreate")]
    partial class initialcreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SplitExpenseTracker.Data.Models.DebtSettlement", b =>
                {
                    b.Property<int>("SettlementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SettlementId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OwedToId")
                        .HasColumnType("int");

                    b.Property<int>("OwerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SettlementDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SettlementId");

                    b.HasIndex("OwedToId");

                    b.HasIndex("OwerId");

                    b.ToTable("DebtSettlements");
                });

            modelBuilder.Entity("SplitExpenseTracker.Data.Models.Expense", b =>
                {
                    b.Property<int>("Expense_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Expense_Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ExpenseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("PaidById")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Expense_Id");

                    b.HasIndex("PaidById");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("SplitExpenseTracker.Data.Models.Member", b =>
                {
                    b.Property<int>("Member_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Member_Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Member_Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("SplitExpenseTracker.Data.Models.DebtSettlement", b =>
                {
                    b.HasOne("SplitExpenseTracker.Data.Models.Member", "OwedTo")
                        .WithMany()
                        .HasForeignKey("OwedToId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SplitExpenseTracker.Data.Models.Member", "Ower")
                        .WithMany()
                        .HasForeignKey("OwerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("OwedTo");

                    b.Navigation("Ower");
                });

            modelBuilder.Entity("SplitExpenseTracker.Data.Models.Expense", b =>
                {
                    b.HasOne("SplitExpenseTracker.Data.Models.Member", "PaidBy")
                        .WithMany()
                        .HasForeignKey("PaidById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaidBy");
                });
#pragma warning restore 612, 618
        }
    }
}
