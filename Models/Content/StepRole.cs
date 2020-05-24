using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Content
{
    public class StepRole
    {
        public StepRole() { }

        public StepRole(Step _step, IdentityRole _role)
        {
            this.Step = _step;
            this.Role = _role;
        }

        [Key]
        [ForeignKey("Step")]
        public Guid StepId { get; set; }
        [Required]
        public virtual Step Step { get; set; }

        [Key]
        [ForeignKey("IdentityRole")]
        public string RoleId { get; set; }
        [Required]
        public virtual IdentityRole Role { get; set; }
    }
}