using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
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

            builder.Entity<SectionFile>()
                .HasKey(t => new { t.SectionId, t.UploadedFileId });

            builder.Entity<SectionRole>()
                .HasKey(t => new { t.SectionId, t.RoleId });

            // builder.Entity<Step>()
            //         .HasMany(act => act.Actions)
            //         .WithOne(st => st.NextStep)
            //         .IsRequired()
            //         .OnDelete(DeleteBehavior.Cascade);

            // builder.Entity<Step>()
            //         .HasMany(act => act.Actions)
            //         .WithOne(st => st.PrevStep)
            //         .IsRequired()
            //         .OnDelete(DeleteBehavior.Cascade);
        }

        #region Users
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<ClientBot> ClientBots { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        #endregion

        public DbSet<BotAction> BotActions { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionRole> SectionRoles { get; set; }
        public DbSet<UploadedFile> UploadedFiles { get; set; }
        public DbSet<SectionFile> SectionFiles { get; set; }
    }
}