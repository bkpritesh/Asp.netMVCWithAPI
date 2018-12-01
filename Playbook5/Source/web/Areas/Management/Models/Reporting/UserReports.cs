using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.Reporting
{
    public class UserReports
    {
        public UserReports()
        {
            PlayList = new List<PlayReports>();
            SnapShot = new SnapShotReport();
        }
        public string PlayerName { get; set; }
        public List<PlayReports> PlayList { get; set; }
        public SnapShotReport SnapShot { get; set; }
    }
}