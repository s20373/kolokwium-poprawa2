﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium_poprawa.Models;

#nullable disable

namespace kolokwium_poprawa.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220628165641_FixMigration")]
    partial class FixMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("kolokwium_poprawa.Models.File", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("FileID")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.HasKey("TeamID");

                    b.ToTable("File");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            FileExtension = "pdf",
                            FileID = 1,
                            FileName = "filename1",
                            FileSize = 128
                        },
                        new
                        {
                            TeamID = 2,
                            FileExtension = "docx",
                            FileID = 2,
                            FileName = "filename2",
                            FileSize = 256
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberID"), 1L, 1);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            MemberName = "Jan",
                            MemberNickName = "jkowalski",
                            MemberSurname = "Kowalski",
                            OrganizationID = 1
                        },
                        new
                        {
                            MemberID = 2,
                            MemberName = "Maciej",
                            MemberSurname = "Nowak",
                            OrganizationID = 2
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Membership", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TeamID");

                    b.HasIndex("MemberID");

                    b.ToTable("Membership");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            MemberID = 1,
                            MembershipDate = new DateTime(1989, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            TeamID = 2,
                            MemberID = 2,
                            MembershipDate = new DateTime(1999, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrganizationID"), 1L, 1);

                    b.Property<string>("OrganizationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organization");

                    b.HasData(
                        new
                        {
                            OrganizationID = 1,
                            OrganizationDomain = "Organization domain 1",
                            OrganizationName = "Organization name 1"
                        },
                        new
                        {
                            OrganizationID = 2,
                            OrganizationDomain = "Organization domain 2",
                            OrganizationName = "Organization name 2"
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"), 1L, 1);

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("TeamDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            OrganizationID = 1,
                            TeamDescription = "TEAM ONE DESCRIPTION",
                            TeamName = "TEAM ONE"
                        },
                        new
                        {
                            TeamID = 2,
                            OrganizationID = 2,
                            TeamName = "TEAM TWO"
                        });
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.File", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Member", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Membership", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("kolokwium_poprawa.Models.Team", "Team")
                        .WithMany("Memberships")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Team", b =>
                {
                    b.HasOne("kolokwium_poprawa.Models.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Member", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("kolokwium_poprawa.Models.Team", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
