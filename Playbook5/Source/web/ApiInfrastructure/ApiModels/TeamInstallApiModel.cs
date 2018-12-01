using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace web.ApiInfrastructure.ApiModels
{
    public class TeamInstallApiModel
    {
        public string TeamId { get; set; }
        public List<TeamInstall> TeamInstalls { get; set; }
    }

    public class Play
    {
        public string DefenseFormation { get; set; }
        public string Name { get; set; }
        [Display(Name = "Formation")]
        public OffenseFormation OffenseFormation { get; set; }
        public string PlayId { get; set; }
        public string Personnel { get; set; }
        public string SvgUrl { get; set; }
        public string PreviewUrl { get; set; }
        public string Type { get; set; }
        public string Hash { get; set; }
        [Display(Name = "Indicator Set")]
        public string IndicatorSet { get; set; }
        public string Install { get; set; }
        
        public DateTime DateCreated { get; set; }
        [Display(Name = "Type")]
        public string PlayType { get; set; }
        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }
    }

    public class TeamInstall
    {
        public string Id { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public List<Play> Plays { get; set; }
        public string TeamInstallId { get; set; }
        public string Title { get; set; }
    }
}