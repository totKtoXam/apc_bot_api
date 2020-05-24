using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Base.SeedData;
using apc_bot_api.Models.Bots;
using apc_bot_api.Models.Content;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace apc_bot_api.Models.Base
{
    public class InitSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var _dbContext = serviceProvider.GetRequiredService<AppDbContext>();
            var _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // _dbContext.Database.EnsureDeleted();
            // _dbContext.Database.EnsureCreated();
            _dbContext.Database.Migrate();


            #region Roles
            RolesData.AddSeedData(_dbContext, _roleManager);
            #endregion

            #region Types
            StepTypesData.AddSeedData(_dbContext);
            FileTypesData.AddSeedData(_dbContext);
            InfoTypes.AddSeedData(_dbContext);
            #endregion

            #region AllUsers
            AllUsersData.AddSeedData(_dbContext, _userManager, _roleManager);
            #endregion

            _dbContext.SaveChanges();


            #region Content
            StepsData.AddSeedData(_dbContext, _roleManager);
            BotActionsData.AddSeedData(_dbContext);
            #endregion
        }
    }
}