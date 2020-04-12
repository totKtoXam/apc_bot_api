using apc_bot_api.Models.Bots;
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
        }

        #region Users
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Student> Students { get; set; }
        #endregion
        public DbSet<BotButton> BotButtons { get; set; }
    }
}