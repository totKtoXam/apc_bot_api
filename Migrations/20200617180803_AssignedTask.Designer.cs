﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using apc_bot_api.Models.Base;

namespace apc_bot_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200617180803_AssignedTask")]
    partial class AssignedTask
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("apc_bot_api.Models.Appeals.EnrolleeAppeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("SentById")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SentById");

                    b.ToTable("EnrolleeAppeals");
                });

            modelBuilder.Entity("apc_bot_api.Models.Appeals.EnrolleeAppealFile", b =>
                {
                    b.Property<Guid>("AppealId")
                        .HasColumnType("uuid");

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.Property<int>("AppealId1")
                        .HasColumnType("integer");

                    b.HasKey("AppealId", "FileId");

                    b.HasIndex("AppealId1");

                    b.HasIndex("FileId");

                    b.ToTable("EnrolleeAppealFiles");
                });

            modelBuilder.Entity("apc_bot_api.Models.AssignedTasks.AssignedTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Finish")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int?>("SetById")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SetById");

                    b.ToTable("AssignedTasks");
                });

            modelBuilder.Entity("apc_bot_api.Models.Base.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("apc_bot_api.Models.Bots.BotAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Condition")
                        .HasColumnType("text");

                    b.Property<Guid?>("CurrentCommandId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsEdit")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("NextCommandId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PrevCommandId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CurrentCommandId");

                    b.HasIndex("NextCommandId");

                    b.HasIndex("PrevCommandId");

                    b.ToTable("BotActions");
                });

            modelBuilder.Entity("apc_bot_api.Models.Bots.ClientBot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("TeleChatId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("VkChatId")
                        .HasColumnType("text");

                    b.Property<string>("WhatsAppChatId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ClientBots");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.Command", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Condition")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NextCommandCode")
                        .HasColumnType("text");

                    b.Property<string>("PrevCommandCode")
                        .HasColumnType("text");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.CommandFile", b =>
                {
                    b.Property<Guid>("CommandId")
                        .HasColumnType("uuid");

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.HasKey("CommandId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("CommandFiles");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.CommandRole", b =>
                {
                    b.Property<Guid>("CommandId")
                        .HasColumnType("uuid");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("CommandId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("CommandRoles");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.InfoFile", b =>
                {
                    b.Property<Guid>("InfoId")
                        .HasColumnType("uuid");

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.HasKey("InfoId", "FileId");

                    b.HasIndex("FileId");

                    b.ToTable("InfoFiles");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.Information", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<Guid?>("CommandId")
                        .HasColumnType("uuid");

                    b.Property<string>("Condition")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("text");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CommandId");

                    b.HasIndex("TypeId");

                    b.ToTable("Informations");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClassificName")
                        .HasColumnType("text");

                    b.Property<string>("Exam")
                        .HasColumnType("text");

                    b.Property<string>("Languages")
                        .HasColumnType("text");

                    b.Property<string>("Price")
                        .HasColumnType("text");

                    b.Property<string>("Short")
                        .HasColumnType("text");

                    b.Property<string>("SpecialtyName")
                        .HasColumnType("text");

                    b.Property<string>("SpecialtyNum")
                        .HasColumnType("text");

                    b.Property<string>("StudyPeriod")
                        .HasColumnType("text");

                    b.Property<string>("StudyType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.UploadedFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("bytea");

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<Guid?>("FileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Size")
                        .HasColumnType("double precision");

                    b.Property<string>("UploadedById")
                        .HasColumnType("text");

                    b.Property<DateTime>("UploadedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("UploadedById");

                    b.ToTable("UploadedFiles");
                });

            modelBuilder.Entity("apc_bot_api.Models.Types.CommandType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Condition")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CommandTypes");
                });

            modelBuilder.Entity("apc_bot_api.Models.Types.FileType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Condition")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("apc_bot_api.Models.Types.InfoType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Condition")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("InfoTypes");
                });

            modelBuilder.Entity("apc_bot_api.Models.Users.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Group")
                        .HasColumnType("text");

                    b.Property<string>("TicketNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("apc_bot_api.Models.Users.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Group")
                        .HasColumnType("text");

                    b.Property<string>("IIN")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("apc_bot_api.Models.Base.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("apc_bot_api.Models.Base.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apc_bot_api.Models.Base.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("apc_bot_api.Models.Base.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apc_bot_api.Models.Appeals.EnrolleeAppeal", b =>
                {
                    b.HasOne("apc_bot_api.Models.Base.AppUser", "SentBy")
                        .WithMany()
                        .HasForeignKey("SentById");
                });

            modelBuilder.Entity("apc_bot_api.Models.Appeals.EnrolleeAppealFile", b =>
                {
                    b.HasOne("apc_bot_api.Models.Appeals.EnrolleeAppeal", "Appeal")
                        .WithMany()
                        .HasForeignKey("AppealId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apc_bot_api.Models.Content.UploadedFile", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apc_bot_api.Models.AssignedTasks.AssignedTask", b =>
                {
                    b.HasOne("apc_bot_api.Models.Users.Teacher", "SetBy")
                        .WithMany()
                        .HasForeignKey("SetById");
                });

            modelBuilder.Entity("apc_bot_api.Models.Bots.BotAction", b =>
                {
                    b.HasOne("apc_bot_api.Models.Content.Command", "CurrentCommand")
                        .WithMany("BotActions")
                        .HasForeignKey("CurrentCommandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("apc_bot_api.Models.Content.Command", "NextCommand")
                        .WithMany()
                        .HasForeignKey("NextCommandId");

                    b.HasOne("apc_bot_api.Models.Content.Command", "PrevCommand")
                        .WithMany()
                        .HasForeignKey("PrevCommandId");
                });

            modelBuilder.Entity("apc_bot_api.Models.Bots.ClientBot", b =>
                {
                    b.HasOne("apc_bot_api.Models.Base.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.Command", b =>
                {
                    b.HasOne("apc_bot_api.Models.Types.CommandType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.CommandFile", b =>
                {
                    b.HasOne("apc_bot_api.Models.Content.Command", "Command")
                        .WithMany()
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apc_bot_api.Models.Content.UploadedFile", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.CommandRole", b =>
                {
                    b.HasOne("apc_bot_api.Models.Content.Command", "Command")
                        .WithMany()
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.InfoFile", b =>
                {
                    b.HasOne("apc_bot_api.Models.Content.UploadedFile", "File")
                        .WithMany()
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apc_bot_api.Models.Content.Information", "Info")
                        .WithMany()
                        .HasForeignKey("InfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.Information", b =>
                {
                    b.HasOne("apc_bot_api.Models.Content.Command", "Command")
                        .WithMany()
                        .HasForeignKey("CommandId");

                    b.HasOne("apc_bot_api.Models.Types.InfoType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("apc_bot_api.Models.Content.UploadedFile", b =>
                {
                    b.HasOne("apc_bot_api.Models.Types.FileType", "File")
                        .WithMany()
                        .HasForeignKey("FileId");

                    b.HasOne("apc_bot_api.Models.Base.AppUser", "UploadedBy")
                        .WithMany()
                        .HasForeignKey("UploadedById");
                });

            modelBuilder.Entity("apc_bot_api.Models.Users.Student", b =>
                {
                    b.HasOne("apc_bot_api.Models.Bots.ClientBot", "ClientBot")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apc_bot_api.Models.Users.Teacher", b =>
                {
                    b.HasOne("apc_bot_api.Models.Bots.ClientBot", "ClientBot")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
