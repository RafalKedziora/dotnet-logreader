﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.Data;

#nullable disable

namespace Services.Migrations
{
    [DbContext(typeof(LFContext))]
    [Migration("20220731183525_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("Data.FtpCredentials", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Host")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PathToFiles")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("FtpCredentials");
                });

            modelBuilder.Entity("Data.UIColors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackGround")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BackGroundButton")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gradient1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gradient2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gradient3")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UIColors");
                });
#pragma warning restore 612, 618
        }
    }
}