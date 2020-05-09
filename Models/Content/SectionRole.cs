using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using apc_bot_api.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace apc_bot_api.Models.Content
{
    public class SectionRole
    {
        [Required]
        public virtual IdentityRole Role { get; set; }
        [Required]
        public virtual Section Section { get; set; }

        // [Required]
        [Key]
        [ForeignKey("AppRole")]
        public string RoleId { get; set; }
        [Key]
        [ForeignKey("Section")]
        public Guid SectionId { get; set; }
    }
}