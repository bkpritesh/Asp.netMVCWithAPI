using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Areas.Management.Models.TeamManagement
{
    public class Play
    {
        public Play()
        {
            OffenseFormation = new OffenseInformation();
        }
        public string TeamId { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string isOwner { get; set; }
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
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public string LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public List<string> Roles { get; set; }
        public string PasswordHash { get; set; }
        public List<object> Logins { get; set; }
        public List<object> Claims { get; set; }
        [Required]
        public string Install { get; set; }
        public OffenseInformation OffenseFormation { get; set; }
        public DefenseFormation DefenseFormation { get; set; }
        [Required]
        public string IndicatorSet { get; set; }
        [Required]
        public string Personnel { get; set; }
        [Required]
        public string PlayType { get; set; }
        [Required]
        public string Hash { get; set; }
        public string PlaybookId { get; set; }
        public string TeamName { get; set; }
        public string PreviewUrl { get; set; }
        public string SvgUrl { get; set; }
        [Display(Name = "Recommended Plays")]
        public string RecommendedPlayList { get; set; }
        public List<RecommendedPlay> RecommendedPlays { get; set; }
        public bool Active { get; set; } = true;
    }

    public class OffenseInformation
    {
        public string Name { get; set; }
        public string FriendlyDisplay { get; set; }
    }

    public class RecommendedPlay
    {
        public string PlayId { get; set; }
    }

}