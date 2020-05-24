using System.Linq;
using apc_bot_api.Constants;
using apc_bot_api.Models.Bots;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Base.SeedData
{
    public class AllUsersData
    {
        public static void AddSeedData(AppDbContext _dbContext, UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            AppUser admin = _userManager.Users.FirstOrDefault(x => x.UserName == "kham.b.13.09@mail.ru");
            if (admin == null)
            {
                admin = new AppUser
                {
                    Email = "kham.b.13.09@mail.ru",
                    UserName = "kham.b.13.09@mail.ru",
                    FirstName = "admin",
                    LastName = "apc",
                    MiddleName = "client",
                    PhoneNumber = "7776660101",
                    EmailConfirmed = true
                };
                var newAdmin = _userManager.CreateAsync(admin, "P@ssw0rd");
                newAdmin.Wait();
                var adminRole = _userManager.AddToRoleAsync(admin, RoleConstants.Admin);
                adminRole.Wait();

                ClientBot adminBotClient = new ClientBot() { User = admin };
                _dbContext.ClientBots.Add(adminBotClient);
            }

            AppUser manager = _userManager.Users.FirstOrDefault(x => x.UserName == "manager@apc.vb");
            if (manager == null)
            {
                manager = new AppUser
                {
                    Email = "manager@apc.vb",
                    UserName = "manager@apc.vb",
                    FirstName = "manager",
                    LastName = "apc",
                    MiddleName = "client",
                    PhoneNumber = "7776660101",
                    EmailConfirmed = true
                };
                var newManager = _userManager.CreateAsync(manager, "P@ssw0rd");
                newManager.Wait();
                var managerRole = _userManager.AddToRoleAsync(manager, RoleConstants.Manager);
                managerRole.Wait();

                ClientBot managerBotClient = new ClientBot() { User = manager };
                _dbContext.ClientBots.Add(managerBotClient);
            }
        }
    }
}