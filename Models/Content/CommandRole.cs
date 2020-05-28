using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Content
{
    public class CommandRole
    {
        public CommandRole() { }

        public CommandRole(Command _command, IdentityRole _role)
        {
            this.Command = _command;
            this.Role = _role;
        }

        [Key]
        [ForeignKey("Command")]
        public Guid CommandId { get; set; }
        [Required]
        public virtual Command Command { get; set; }

        [Key]
        [ForeignKey("IdentityRole")]
        public string RoleId { get; set; }
        [Required]
        public virtual IdentityRole Role { get; set; }
    }

    public class CommandRoleViewModel
    {
        public string CommandId { get; set; }
        public string CommandCode { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}