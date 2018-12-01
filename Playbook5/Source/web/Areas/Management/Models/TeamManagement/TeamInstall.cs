using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using web.Areas.Management.Models.Reporting;

namespace web.Areas.Management.Models.TeamManagement
{
    public class TeamInstall
    {
        public string TeamId { get; set; }
        public List<TeamInstallDTO> TeamInstalls { get; set; }
    }

    public class PlayInstall
    {
        public string DefenseFormation { get; set; }
        public string Name { get; set; }
        public string OffenseFormation { get; set; }
        public string PlayId { get; set; }
        public string Personnel { get; set; }
        public string SvgUrl { get; set; }
        public string Type { get; set; }
        public string Hash { get; set; }
        public string IndicatorSet { get; set; }
        public string Install { get; set; }
    }

    public class TeamInstallDTO
    {
        public TeamInstallDTO()
        {
            Plays = new List<PlayInstall>();
        }

        public string Id { get; set; }
        [Display(Name = "Date Issue")]
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public List<PlayInstall> Plays { get; set; }
        public string TeamInstallId { get; set; }
        [Required]
        public string Title { get; set; }
        public string TeamId { get; set; }
        public bool Active { get; set; }
        [Display(Name = "Coach")]
        public string CoachId { get; set; }
        public ApplicationUser Coach { get; set; }
    }

    public class EmailDTO
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}