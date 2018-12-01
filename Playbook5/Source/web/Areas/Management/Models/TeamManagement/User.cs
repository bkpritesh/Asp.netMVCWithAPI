using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.TeamManagement
{
    public class User
    {
        //public string userId { get; set; } 
        //public string teamId { get; set; } 
        //string firstName;
        //string lastName;
        //string phone;
        //string email;
        //string password;
        //string confirmPassword;
        public string UserId { get; set; }
        public string TeamId { get; set; }
        [Required]
        public string Phone { get; set; } = "";
        [DisplayName("First Name")]
        [Required]
        public string FirstName { get; set; } = "";
        [DisplayName("Last Name")]
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        public object isOwner { get; set; }
        public string Position { get; set; } = "";
        public object CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public object ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string SecurityStamp { get; set; }
        [Required]
        public string Email { get; set; } = "";
        public bool EmailConfirmed { get; set; }
        public object PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public object LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public List<string> Roles { get; set; }
        public string PasswordHash { get; set; }
        public List<object> Logins { get; set; }
        public List<object> Claims { get; set; }
        public string UserRole { get; set; } = "";
        [Required]
        public string UserRoleId { get; set; }

    }
}