
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using web.Areas.Management.Models.Reporting;

namespace web.Areas.Management.ViewModels
{
    public class ReportingViewModel
    {
        public const string BASEURL = "http://playbook5servicev2.azurewebsites.net/";
        public ReportingViewModel()
        {
            ReportingModel = new TeamReports();
        }
        public TeamReports ReportingModel { get; set; }
        public List<Teams> TeamList { get; set; }
        public IEnumerable<SelectListItem> TeamSelectList { get; set; }
        public string TeamId { get; set; }
        public async Task<TeamReports> GetTeamReporting(string teamId)
        {
            var client = new RestClient();
            client.BaseUrl = new System.Uri(BASEURL);
            var request = new RestRequest("api/Reporting/TeamByIdReporting?Id=" + teamId, Method.GET);

            IRestResponse<TeamReports> response = client.Execute<TeamReports>(request);
            if (response.Data != null)
            {
                ReportingModel = response.Data;
            }
            return ReportingModel;
        }
        public void Load()
        {
            TeamSelectList = GetTeams().Select(c => new SelectListItem { Value = c.Id , Text = c.Name });
        }
        public List<Teams> GetTeams()
        {
            var client = new RestClient();
            client.BaseUrl = new System.Uri(BASEURL);
            var request = new RestRequest("api/Reporting/GetAllTeamsForReporting", Method.GET);

            IRestResponse <List<Teams>> response = client.Execute<List<Teams>>(request);
            if (response.Data != null)
            {
                TeamList = response.Data.ToList();
            }

            return TeamList;
        }
    }
}