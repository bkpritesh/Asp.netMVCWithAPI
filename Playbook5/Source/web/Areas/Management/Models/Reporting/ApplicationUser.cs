using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.Reporting
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool isOwner { get; set; }
        public string Position { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        
    }
}