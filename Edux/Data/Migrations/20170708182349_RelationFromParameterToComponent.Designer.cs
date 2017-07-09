using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Edux.Data;
using Edux.Models;

namespace Edux.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170708182349_RelationFromParameterToComponent")]
    partial class RelationFromParameterToComponent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Edux.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Edux.Models.Component", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<long>("ComponentTypeId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<long?>("ParentComponentId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("View")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("ComponentTypeId");

                    b.HasIndex("ParentComponentId");

                    b.ToTable("Components");
                });

            modelBuilder.Entity("Edux.Models.ComponentType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("ComponentTypes");
                });

            modelBuilder.Entity("Edux.Models.Entity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<string>("PluralName")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Edux.Models.Page", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllowedRoles");

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("LayoutView")
                        .HasMaxLength(200);

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaKeywords");

                    b.Property<string>("MetaTitle");

                    b.Property<long?>("ParentPageId");

                    b.Property<long>("Position");

                    b.Property<string>("Slug")
                        .HasMaxLength(200);

                    b.Property<string>("Title")
                        .HasMaxLength(200);

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("View")
                        .HasMaxLength(200);

                    b.Property<long>("ViewCount");

                    b.HasKey("Id");

                    b.HasIndex("ParentPageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Edux.Models.PageComponent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<long>("ComponentId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<long>("PageId");

                    b.Property<long>("Position");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("PageId");

                    b.ToTable("PageComponents");
                });

            modelBuilder.Entity("Edux.Models.Parameter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<long>("ComponentId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200);

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<int>("Position");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("Edux.Models.ParameterValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<long?>("ComponentId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<long?>("ParameterId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("ParameterId");

                    b.ToTable("ParameterValues");
                });

            modelBuilder.Entity("Edux.Models.Property", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<int?>("DataType");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200);

                    b.Property<long>("EntityId");

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Name")
                        .HasMaxLength(200);

                    b.Property<int>("Position");

                    b.Property<int>("PropertyType");

                    b.Property<int>("StringLength");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Edux.Models.PropertyValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AppTenantId");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<long?>("EntityId");

                    b.Property<long?>("PropertyId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("EntityId");

                    b.HasIndex("PropertyId");

                    b.ToTable("PropertyValues");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
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

            modelBuilder.Entity("Edux.Models.Component", b =>
                {
                    b.HasOne("Edux.Models.ComponentType", "ComponentType")
                        .WithMany()
                        .HasForeignKey("ComponentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edux.Models.Component", "ParentComponent")
                        .WithMany("ChildComponents")
                        .HasForeignKey("ParentComponentId");
                });

            modelBuilder.Entity("Edux.Models.Page", b =>
                {
                    b.HasOne("Edux.Models.Page", "ParentPage")
                        .WithMany("ChildPages")
                        .HasForeignKey("ParentPageId");
                });

            modelBuilder.Entity("Edux.Models.PageComponent", b =>
                {
                    b.HasOne("Edux.Models.Component", "Component")
                        .WithMany("PageComponents")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Edux.Models.Page", "Page")
                        .WithMany("PageComponents")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edux.Models.Parameter", b =>
                {
                    b.HasOne("Edux.Models.Component", "Component")
                        .WithMany("Parameters")
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edux.Models.ParameterValue", b =>
                {
                    b.HasOne("Edux.Models.Component", "Component")
                        .WithMany("ParameterValues")
                        .HasForeignKey("ComponentId");

                    b.HasOne("Edux.Models.Parameter", "Parameter")
                        .WithMany()
                        .HasForeignKey("ParameterId");
                });

            modelBuilder.Entity("Edux.Models.Property", b =>
                {
                    b.HasOne("Edux.Models.Entity", "Entity")
                        .WithMany("Properties")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Edux.Models.PropertyValue", b =>
                {
                    b.HasOne("Edux.Models.Entity", "Entity")
                        .WithMany("PropertyValues")
                        .HasForeignKey("EntityId");

                    b.HasOne("Edux.Models.Property", "Property")
                        .WithMany("PropertyValues")
                        .HasForeignKey("PropertyId");
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
                    b.HasOne("Edux.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Edux.Models.ApplicationUser")
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

                    b.HasOne("Edux.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
