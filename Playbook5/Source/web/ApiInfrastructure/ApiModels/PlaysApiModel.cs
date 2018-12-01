using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.ApiInfrastructure.ApiModels
{
    public class PlaysApiModel
    {
        public string TeamId { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public object isOwner { get; set; }
        public string Position { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string SecurityStamp { get; set; }
        public string Email { get; set; }
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
    }
}
