﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared;

public partial class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        : base(options)
    {
    }
    #region 表结构
    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Borrowrecord> BorrowRecords { get; set; }

    public virtual DbSet<Fine> Fines { get; set; }

    public virtual DbSet<User> Users { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_visibility");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Bookid).HasName("books_pkey");

            entity.ToTable("books");

            entity.HasIndex(e => e.Isbn, "books_isbn_key").IsUnique();

            entity.Property(e => e.Bookid).HasColumnName("bookid");
            entity.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("author");
            entity.Property(e => e.Availablecopies).HasColumnName("availablecopies");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Createtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Isbn)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("isbn");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Publishdate).HasColumnName("publishdate");
            entity.Property(e => e.Publisher)
                .HasMaxLength(255)
                .HasColumnName("publisher");
            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.Totalcopies).HasColumnName("totalcopies");
            entity.Property(e => e.Updatetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");
        });

        modelBuilder.Entity<Borrowrecord>(entity =>
        {
            entity.HasKey(e => e.Recordid).HasName("borrowrecords_pkey");

            entity.ToTable("borrowrecords");

            entity.Property(e => e.Recordid).HasColumnName("recordid");
            entity.Property(e => e.Bookid)
                .ValueGeneratedOnAdd()
                .HasColumnName("bookid");
            entity.Property(e => e.Borrowdate).HasColumnName("borrowdate");
            entity.Property(e => e.Createtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Duedate).HasColumnName("duedate");
            entity.Property(e => e.Returndate).HasColumnName("returndate");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Updatetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");
            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnName("userid");

            entity.HasOne(d => d.Book).WithMany(p => p.Borrowrecords)
                .HasForeignKey(d => d.Bookid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("borrowrecords_bookid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Borrowrecords)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("borrowrecords_userid_fkey");
        });

        modelBuilder.Entity<Fine>(entity =>
        {
            entity.HasKey(e => e.Fineid).HasName("fines_pkey");

            entity.ToTable("fines");

            entity.Property(e => e.Fineid).HasColumnName("fineid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Createtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Recordid)
                .ValueGeneratedOnAdd()
                .HasColumnName("recordid");
            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.Updatetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");
            entity.Property(e => e.Userid)
                .ValueGeneratedOnAdd()
                .HasColumnName("userid");

            entity.HasOne(d => d.Record).WithMany(p => p.Fines)
                .HasForeignKey(d => d.Recordid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fines_recordid_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Fines)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fines_userid_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.Userid).HasColumnName("userid")
                                          .ValueGeneratedOnAdd()
                                          .IsRequired()
                                          .UseSerialColumn();
            entity.Property(e => e.Createtime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createtime");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(20)
                .HasColumnName("phonenumber");
            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("role");
            entity.Property(e => e.Updatetime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updatetime");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}