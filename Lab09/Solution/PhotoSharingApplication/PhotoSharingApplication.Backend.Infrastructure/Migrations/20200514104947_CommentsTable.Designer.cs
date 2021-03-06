﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhotoSharingApplication.Backend.Infrastructure.Data;

namespace PhotoSharingApplication.Backend.Infrastructure.Migrations
{
    [DbContext(typeof(PhotoSharingApplicationContext))]
    [Migration("20200514104947_CommentsTable")]
    partial class CommentsTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.3.20181.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.HasSequence("comments_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("photos_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("PhotoSharingApplication.Shared.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "comments_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("SubmittedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PhotoId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PhotoSharingApplication.Shared.Core.Entities.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "photos_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PhotoFile")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("PhotoSharingApplication.Shared.Core.Entities.Comment", b =>
                {
                    b.HasOne("PhotoSharingApplication.Shared.Core.Entities.Photo", "Photo")
                        .WithMany("Comments")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
