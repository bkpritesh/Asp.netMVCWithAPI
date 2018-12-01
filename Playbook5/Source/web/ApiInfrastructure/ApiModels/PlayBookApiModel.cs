using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.ApiInfrastructure.ApiModels
{
    public class PlayBookApiModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public OffenseFormation OffenseFormation { get; set; }
        public DefenseFormation DefenseFormation { get; set; }
        public string SvgUrl { get; set; }
        public string PreviewUrl { get; set; }
        public string Personnel { get; set; }
        public string PlayType { get; set; }
        public string PlaybookId { get; set; }
        public string IndicatorSet { get; set; }
        public string Install { get; set; }
        public object Hash { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
    public class OffenseFormation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendlyDisplay { get; set; }
    }

    public class DefenseFormation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendlyDisplay { get; set; }
    }
}