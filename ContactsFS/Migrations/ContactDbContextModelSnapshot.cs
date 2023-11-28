﻿// <auto-generated />
using System;
using ContactsFS.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ContactsFS.Migrations
{
    [DbContext(typeof(ContactDbContext))]
    partial class ContactDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ContactsFS.Data.Models.ContactDb", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Contacts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = "1990-05-12",
                            JobTitle = "Developer",
                            MobilePhone = "375295053167",
                            Name = "Pavel"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = "2000-04-13",
                            JobTitle = "Driver",
                            MobilePhone = "375441101533",
                            Name = "Ivan"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = "1992-03-18",
                            JobTitle = "Designer",
                            MobilePhone = "375441471238",
                            Name = "Alex"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = "1997-11-22",
                            JobTitle = "HR",
                            MobilePhone = "375447130154",
                            Name = "Sergey"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = "1993-08-14",
                            JobTitle = "Developer",
                            MobilePhone = "375291347306",
                            Name = "Victor"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
