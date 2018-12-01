using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.Reporting
{
    public class Teams
    {
        public string Id { get; set; }
        public string AccessCode { get; set; }
        public string Name { get; set; }
        public string Field { get; set; }
        public string AccountOwner { get; set; }
        public string AccountPackage { get; set; }
        public DateTime AccountStartDate { get; set; }
        public string AccountManager { get; set; }
        public string LeagueDivConf { get; set; }
        public string Address { get; set; }
        public string StateOrProvince { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string RosterCount { get; set; }
        public string TotalCustomPlays { get; set; }
        public string SecurityStatus { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ZipCode { get; set; }
        public string PaymentStatus { get; set; }
        public string AccountStatus { get; set; }
        public string Notes { get; set; }
        public string ArchievedPackages { get; set; }
        public string SecurityTickets { get; set; }
        public string SupportTickets { get; set; }

    }
}