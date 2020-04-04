using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apc_bot_api.Models.Base
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _dbContext      = serviceProvider.GetRequiredService<AppDbContext>                  ();
            var _userManager    = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>  ();
            var _roleManager    = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>     ();

            // _dbContext.Database.EnsureDeleted();
            // _dbContext.Database.EnsureCreated();
        }
    }
}