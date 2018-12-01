using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.TeamManagement
{
    public class UserHistory
    {
        public string Timestamp { get; set; }
        public string Action { get; set; }
        public string Positions { get; set; }
        public string Reps { get; set; }
        public string Key { get; set; }
    }
}