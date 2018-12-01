using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.Reporting
{
    public class TeamReports
    {
        public TeamReports()
        {
            UserList = new List<UserReports>();
        }
        public string TeamName { get; set; }
        public List<UserReports> UserList { get; set; }
    }
}