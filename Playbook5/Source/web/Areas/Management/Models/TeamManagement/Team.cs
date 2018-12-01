using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Areas.Management.Models.TeamManagement
{
    public class Team
    {
        public Team()
        {
            TeamUsers = new List<TeamUser>();
            Plays = new List<Play>();
            Playbooks = new List<PlayBook>();
            TeamInstall = new TeamInstall();
        }

        public string Id { get; set; }

        [Display(Name = "Access Code")]
        [Required]
        public string AccessCode { get; set; }

        [Display(Name = "Team Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Field Size")]
        [Required]
        public string Field { get; set; }

        [Display(Name = "Account Representative")]
        [Required]
        public string AccountOwner { get; set; }

        [Display(Name = "Subscription Package")]
        [Required]
        public string AccountPackage { get; set; }

        [Display(Name = "Subscription Date")]
        public DateTime? AccountStartDate { get; set; }
        [Display(Name = "Representative")]
        [Required]
        public string AccountManager { get; set; }

        [Display(Name = "League/division/conference")]
        [Required]
        public string LeagueDivConf { get; set; }

        [Display(Name = "Street Address")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "State")]
        [Required]
        public string StateOrProvince { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Required]
        public string CountryId { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Language")]
        [Required]
        public LanguageEnum Language { get; set; }

        [Display(Name = "Roster")]
        public int? RosterCount { get; set; }

        [Display(Name = "Total Pays")]
        public int? TotalCustomPlays { get; set; }

        public string SecurityStatus { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "Zip Code")]
        [Required]
        public string ZipCode { get; set; }

        [Display(Name = "Payment Status")]
        [Required]
        public PaymentStatusEnum PaymentStatus { get; set; }

        [Display(Name = "Account Status")]
        [Required]
        public AccountStatusEnum AccountStatus { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Archived Packages")]
        public string ArchivedPackages { get; set; }

        [Display(Name = "Security Tickets")]
        public string SecurityTickets { get; set; }

        [Display(Name = "Support Tickets")]
        public string SupportTickets { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        
        public List<TeamUser> TeamUsers { get; set; }
        public List<PlayBook> Playbooks { get; set; }
        public List<Play> Plays { get; set; }
        public TeamInstall TeamInstall { get; set; }


        //string teamId;
        //string name;
        //DateTime createDate;
        //DateTime expirationDate;
        //User[] users;
        //PlayBook[] playbooks;
    }
}