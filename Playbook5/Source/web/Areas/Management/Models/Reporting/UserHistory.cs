using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.Reporting
{
    public class UserHistory
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Action { get; set; }
        public string Postitions { get; set; }
        public string Reps { get; set; }
        public string Key { get; set; }

    }
}