﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models;

public partial class CapitalDb : DbContext
{
    public CapitalDb()
    {
    }

    public CapitalDb(DbContextOptions<CapitalDb> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeAddition> EmployeeAdditions { get; set; }

    public virtual DbSet<EmployyeDetail> EmployyeDetails { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<TypeList> TypeLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Global.ApiConnetion);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeAddition>(entity =>
        {
            entity.ToTable("EmployeeAddition");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeAdditions)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_EmployeeAddition_EmployyeDetails");

            entity.HasOne(d => d.Que).WithMany(p => p.EmployeeAdditions)
                .HasForeignKey(d => d.QueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeAddition_Question1");

            entity.HasOne(d => d.Type).WithMany(p => p.EmployeeAdditions)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK_EmployeeAddition_TypeList");
        });

        modelBuilder.Entity<EmployyeDetail>(entity =>
        {
            entity.Property(e => e.CretaedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CurrentResidence)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DateOfbirth).HasColumnName("DateOFBirth");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Idnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("IDNumber");
            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Remark).HasColumnType("text");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.ToTable("Question");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Questions)
                .IsRequired()
                .HasColumnType("text");
            entity.Property(e => e.UpadtedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpadtedDate).HasColumnName("upadtedDate");

            entity.HasOne(d => d.Type).WithMany(p => p.Questions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Question_TypeList");
        });

        modelBuilder.Entity<TypeList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Type");

            entity.ToTable("TypeList");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}