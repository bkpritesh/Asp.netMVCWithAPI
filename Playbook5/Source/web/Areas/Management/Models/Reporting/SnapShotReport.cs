using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.Reporting
{
    public class SnapShotReport
    {
        public string MostViewedPlay { get; set; }
        public string MostViewFromPosition { get; set; }
        public string LeastViewFromPosition { get; set; }
        public string OverallPercentage { get; set; }
        public string AmountOfPlaysWithoutKeyIndicator { get; set; }
        public string LeastViewedPlay { get; set; }
        public string TotalReps { get; set; }
        public string TotalIncorrect { get; set; }
        public string TotalCorrect { get; set; }
    }
}