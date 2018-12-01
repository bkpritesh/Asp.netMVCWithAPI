using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Areas.Management.Models.TeamManagement
{
    public class TeamNote
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        //public bool Active { get; set; } = true;
    }

    public class TeamNoteList
    {
        public TeamNoteList()
        {
            TeamNotes = new List<TeamNote>();
        }
        public List<TeamNote> TeamNotes { get; set; }
    }
}