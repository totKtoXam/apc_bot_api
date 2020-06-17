using apc_bot_api.Models.Appeals;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using apc_bot_api.Models.Types;
using apc_bot_api.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace apc_bot_api.Models.Base
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //     builder.Entity<Command>()
            //             .HasMany(st => st.CommandFiles)
            //             .WithOne(sf => sf.Command)
            //             .OnDelete(DeleteBehavior.Cascade);

            //     builder.Entity<Command>()
            //             .HasMany(st => st.CommandRoles)
            //             .WithOne(sr => sr.Command)
            //             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CommandFile>()
                    .HasKey(t => new { t.CommandId, t.FileId });

            builder.Entity<CommandRole>()
                    .HasKey(t => new { t.CommandId, t.RoleId });

            builder.Entity<Command>()
                    .HasMany(cmd => cmd.BotActions)
                    .WithOne(cmd => cmd.CurrentCommand)
                    .OnDelete(DeleteBehavior.Cascade);


            //     builder.Entity<Information>()
            //             .HasMany(info => info.InfoFiles)
            //             .WithOne(infFl => infFl.Info)
            //             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<InfoFile>()
                    .HasKey(t => new { t.InfoId, t.FileId });


            //     builder.Entity<EnrolleeAppeal>()
            //             .HasMany(ea => ea.EnrolleeAppealFiles)
            //             .WithOne(eaf => eaf.Appeal)
            //             .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EnrolleeAppealFile>()
                    .HasKey(t => new { t.AppealId, t.FileId });
            // builder.Entity<Command>()
            //         .HasMany(act => act.Actions)
            //         .WithOne(st => st.PrevCommand)
            //         .IsRequired()
            //         .OnDelete(DeleteBehavior.Cascade);
        }

        #region Users
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ClientBot> ClientBots { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        #endregion

        #region Content
        public DbSet<InfoFile> InfoFiles { get; set; }
        public DbSet<Information> Informations { get; set; }

        public DbSet<Command> Commands { get; set; }
        public DbSet<CommandRole> CommandRoles { get; set; }
        public DbSet<CommandFile> CommandFiles { get; set; }

        public DbSet<UploadedFile> UploadedFiles { get; set; }
        #endregion

        #region Types
        public DbSet<CommandType> CommandTypes { get; set; }
        public DbSet<InfoType> InfoTypes { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        #endregion

        #region Bots
        public DbSet<BotAction> BotActions { get; set; }
        #endregion

        #region Appeals
        public DbSet<EnrolleeAppeal> EnrolleeAppeals { get; set; }
        public DbSet<EnrolleeAppealFile> EnrolleeAppealFiles { get; set; }
        #endregion

        public DbSet<Speciality> Specialities { get; set; }
    }
}