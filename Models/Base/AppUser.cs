using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apc_bot_api.Models.Base
{
    public class AppUser : IdentityUser
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AppUser(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager
        )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<string>> GetRoles(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            List<string> rolesList = new List<string>();
            foreach (var role in roles)
                rolesList.Add(role);
            return rolesList;
        }

        public AppUser() { }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [NotMapped]
        private DateTime _createdDate { get; set; }
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = DateTime.Now; }
        }

        public bool IsActive { get; set; }
    }

    public class UserViewModel
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public bool VkIsActive { get; set; }
        public bool TeleIsActive { get; set; }
        public bool WhatsAppIsActive { get; set; }
        public bool IsActive { get; set; }
        public string CreatedDate { get; set; }
    }

    public class UserViewModelList<TModel>
    {
        public List<TModel> UserList { get; set; }

        public ErrorViewModel ErrorViewModel { get; set; }

        public int Page { get; set; }
        public int Size { get; set; }
    }
}