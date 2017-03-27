﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CloudApp.Data;

namespace CloudApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170317121949_migr3")]
    partial class migr3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Custmer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<long>("SampleId");

                    b.HasKey("Id");

                    b.HasIndex("SampleId");

                    b.ToTable("Custmer");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Instrument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount");

                    b.Property<string>("Area");

                    b.Property<string>("BDiscrib");

                    b.Property<string>("Locat");

                    b.Property<long>("QuotationId");

                    b.Property<string>("SNum");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Quotation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bank");

                    b.Property<string>("Complate");

                    b.Property<long>("CustmerId");

                    b.Property<string>("FBatch");

                    b.Property<DateTime>("QDate");

                    b.Property<string>("SCustmer");

                    b.Property<string>("Sign");

                    b.HasKey("Id");

                    b.HasIndex("CustmerId");

                    b.ToTable("Quotation");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R1Smaple", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Agbuild");

                    b.Property<string>("Area");

                    b.Property<string>("CaseBuild");

                    b.Property<string>("City");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DateSNum");

                    b.Property<string>("Gada");

                    b.Property<string>("Local");

                    b.Property<string>("Napartment");

                    b.Property<string>("Npiece");

                    b.Property<string>("OccBuild");

                    b.Property<string>("Owner");

                    b.Property<string>("Plane");

                    b.Property<string>("ResWland");

                    b.Property<string>("SCustmer");

                    b.Property<string>("SNum");

                    b.Property<string>("Street");

                    b.Property<string>("StyleBuild");

                    b.Property<string>("Tbuild");

                    b.Property<string>("Wland");

                    b.HasKey("Id");

                    b.HasIndex("CustmerId");

                    b.ToTable("R1Smaple");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R2Smaple", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Agbuild");

                    b.Property<string>("Area");

                    b.Property<string>("CaseBuild");

                    b.Property<string>("City");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DateSNum");

                    b.Property<string>("Gada");

                    b.Property<string>("Local");

                    b.Property<string>("Napartment");

                    b.Property<string>("Npiece");

                    b.Property<string>("OccBuild");

                    b.Property<string>("Owner");

                    b.Property<string>("Plane");

                    b.Property<string>("ResWland");

                    b.Property<string>("SCustmer");

                    b.Property<string>("SNum");

                    b.Property<string>("Street");

                    b.Property<string>("StyleBuild");

                    b.Property<string>("Tbuild");

                    b.Property<string>("Wland");

                    b.HasKey("Id");

                    b.HasIndex("CustmerId");

                    b.ToTable("R2Smaple");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Sample", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Treatment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Agbuild");

                    b.Property<string>("Area");

                    b.Property<string>("CaseBuild");

                    b.Property<string>("City");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DateSNum");

                    b.Property<string>("Gada");

                    b.Property<bool>("IsAduit");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsIntered");

                    b.Property<bool>("IsThmin");

                    b.Property<string>("Local");

                    b.Property<string>("Napartment");

                    b.Property<string>("Npiece");

                    b.Property<string>("OccBuild");

                    b.Property<string>("Owner");

                    b.Property<string>("Plane");

                    b.Property<string>("ResWland");

                    b.Property<string>("SCustmer");

                    b.Property<string>("SNum");

                    b.Property<string>("Street");

                    b.Property<string>("StyleBuild");

                    b.Property<string>("Tbuild");

                    b.Property<string>("Wland");

                    b.HasKey("Id");

                    b.HasIndex("CustmerId");

                    b.ToTable("Treatment");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Custmer", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Sample", "Sample")
                        .WithMany("Custmers")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Instrument", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Quotation", "Quotation")
                        .WithMany("Instruments")
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Quotation", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany("Quotations")
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R1Smaple", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany()
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R2Smaple", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany()
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Treatment", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany("Treatments")
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}