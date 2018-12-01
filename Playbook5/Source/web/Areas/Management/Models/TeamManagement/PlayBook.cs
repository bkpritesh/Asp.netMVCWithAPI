using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Areas.Management.Models.TeamManagement
{
    public class PlayBook
    {
        public PlayBook()
        {
            this.PlaybookType = new PlaybookTypes();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string SvgUrl { get; set; }
        public string PreviewUrl { get; set; }
        public string Personnel { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string TeamId { get; set; }
        //public string PlayboolTypeString { get; set; }
        public PlaybookTypes PlaybookType { get; set; }

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
    public class PlaybookTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
    }
}