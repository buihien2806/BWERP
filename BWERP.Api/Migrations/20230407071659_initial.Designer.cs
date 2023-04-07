﻿// <auto-generated />
using System;
using BWERP.Api.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BWERP.Api.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20230407071659_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BWERP.Api.Entities.AppMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Icon")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("isEnable")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AppMenus", (string)null);
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppMenuPermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleMenuId")
                        .HasColumnType("int");

                    b.HasKey("PermissionId");

                    b.HasIndex("RoleMenuId");

                    b.ToTable("AppMenuPermissions", (string)null);
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("AppPermissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "View"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Create"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Update"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AppRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                            ConcurrencyStamp = "256054e1-ff8e-49a6-a6fd-b83556d56873",
                            Description = "Administrator",
                            Name = "admin",
                            NormalizedName = "admin"
                        });
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppRoleMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("AppRoleMenus", (string)null);
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d47596ea-375e-47e8-93d4-e3bd923a748f",
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "orib@a2-cloud.com",
                            EmailConfirmed = true,
                            FirstName = "Hien",
                            LastLogin = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Bui",
                            LockoutEnabled = false,
                            NormalizedEmail = "ORIB@A2-CLOUD.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEOxL3TQIU5isurxE+YnPwOaZum5f4PqO/g6/e2eM9EXZdqWBgVcev+gm2PVuNj82JA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "54205dc6-2910-4cb1-b980-471830d0db0a",
                            TwoFactorEnabled = false,
                            UserName = "admin",
                            isActive = false
                        });
                });

            modelBuilder.Entity("BWERP.Api.Entities.DailyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("TodayTask")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("TomorrowTask")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("DailyReports", (string)null);
                });

            modelBuilder.Entity("BWERP.Api.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("BWERP.Api.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssigneeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.ToTable("Tasks", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                            RoleId = new Guid("8d04dce2-969a-435d-bba4-df3f325983dc")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens", (string)null);
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppMenuPermission", b =>
                {
                    b.HasOne("BWERP.Api.Entities.AppPermission", "AppPermission")
                        .WithMany("MenuPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BWERP.Api.Entities.AppRoleMenu", "AppRoleMenu")
                        .WithMany("MenuPermissions")
                        .HasForeignKey("RoleMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppPermission");

                    b.Navigation("AppRoleMenu");
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppRoleMenu", b =>
                {
                    b.HasOne("BWERP.Api.Entities.AppMenu", "AppMenu")
                        .WithMany("AppRoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BWERP.Api.Entities.AppRole", "AppRole")
                        .WithMany("AppRoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppMenu");

                    b.Navigation("AppRole");
                });

            modelBuilder.Entity("BWERP.Api.Entities.DailyReport", b =>
                {
                    b.HasOne("BWERP.Api.Entities.Department", "Department")
                        .WithMany("DailyReports")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BWERP.Api.Entities.AppUser", "AppUser")
                        .WithMany("DailyReports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("BWERP.Api.Entities.Task", b =>
                {
                    b.HasOne("BWERP.Api.Entities.AppUser", "Assignee")
                        .WithMany("Tasks")
                        .HasForeignKey("AssigneeId");

                    b.Navigation("Assignee");
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppMenu", b =>
                {
                    b.Navigation("AppRoleMenus");
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppPermission", b =>
                {
                    b.Navigation("MenuPermissions");
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppRole", b =>
                {
                    b.Navigation("AppRoleMenus");
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppRoleMenu", b =>
                {
                    b.Navigation("MenuPermissions");
                });

            modelBuilder.Entity("BWERP.Api.Entities.AppUser", b =>
                {
                    b.Navigation("DailyReports");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BWERP.Api.Entities.Department", b =>
                {
                    b.Navigation("DailyReports");
                });
#pragma warning restore 612, 618
        }
    }
}