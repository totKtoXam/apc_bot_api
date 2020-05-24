using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Base.SeedData
{
    public static class RolesData
    {
        public static void AddSeedData(AppDbContext _dbContext, RoleManager<IdentityRole> _roleManager)
        {
            var newRoles = new List<string>()
            {
                "admin", "teacher", "student", "enrollee", "manager"
            };
            var roles = _roleManager.Roles.Select(x => x.Name).ToList();
            var rolesDiff = newRoles.Except(roles).ToList();
            if (rolesDiff.Count() > 0)
            {
                foreach (var value in rolesDiff)
                {
                    var role = new IdentityRole { Name = value };
                    var asyncTask = _roleManager.CreateAsync(role);
                    asyncTask.Wait();
                }
            }
        }
    }
}