using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace apc_bot_api.Models.Base
{
    public class AppUser : IdentityUser
    {
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