using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web.ApiInfrastructure.Client;
using web.Areas.Management.Models;
using web.Areas.Management.Models.TeamManagement;
using web.Models;

namespace web.Areas.Management.ViewModels
{
    public class TeamViewModel
    {
        public TeamViewModel()
        {
            TeamModel = new List<Team>();
            Team = new Team();
            CountrySelectList = new List<SelectListItem>();
        }

        public List<Team> TeamModel { get; set; }
        public Team Team { get; set; }
        public IEnumerable<SelectListItem> CountrySelectList { get; set; }


        public async Task<List<Team>> GetTeams()
        {
            TeamModel = await new RestHelper().Get<List<Team>>("api/TeamManagement/GetAllTeams");
            return TeamModel;
        }


        public async Task Load(string teamId = "")
        {
            if (string.IsNullOrEmpty(teamId))
            {
                await GetTeams();
            }
            else
            {
                var allCountries = await GetAllCountry();
                CountrySelectList = allCountries.Select(c => new SelectListItem { Value = c.Id, Text = c.Name }).ToList();
                await GetTeam(teamId);
                var country = allCountries.FirstOrDefault(x => string.Equals(x.Name, Team.Country, StringComparison.OrdinalIgnoreCase));
                Team.CountryId = country.Id;
                Team.TeamUsers = await GetUsersByTeamId(teamId);
                Team.Plays = await GetAllPlaysByTeamId(teamId);
                Team.Playbooks = await GetAllPlaybooksByTeamId(teamId);
                Team.TeamInstall = await GetAllTeamInstalledByTeamId(teamId);
            }
        }

        public async Task<List<Country>> GetAllCountry()
        {
            return await new RestHelper().Get<List<Country>>($"api//TeamManagement/GetAllCountries");
        }

        public async Task<Team> GetTeam(string teamId)
        {
            Team = await new RestHelper().Get<Team>($"api/TeamManagement/GetTeam?Id={teamId}");
            return Team;
        }

        public async Task<List<TeamUser>> GetUsersByTeamId(string teamId)
        {
            return await new RestHelper().Get<List<TeamUser>>($"api/TeamManagement/GetAllUsersByTeamId?teamid={teamId}");
        }

        public async Task<List<Play>> GetAllPlaysByTeamId(string teamId)
        {
            return await new RestHelper().Get<List<Play>>($"api/PlaybookManagement/GetAllPlaysByTeamId?teamid={teamId}");
        }

        public async Task<List<PlayBook>> GetAllPlaybooksByTeamId(string teamId)
        {
            return await new RestHelper().Get<List<PlayBook>>($"api/PlaybookManagement/GetAllPlaybooksByTeamId?teamid={teamId}");
        }

        public async Task<TeamInstall> GetAllTeamInstalledByTeamId(string teamId)
        {
            return await new RestHelper().Get<TeamInstall>($"api/TeamManagement/TeamInstallsByIdGet/{teamId}");
        }

        public async Task<Team> CreateUpdateTeam()
        {
            return await new RestHelper().Post<Team>($"api/TeamManagement/CreateTeam", Team);
        }

        public async Task<PlayBook> CreateUpdateTeamPlayBook(PlayBook newPlayBook)
        {
            return await new RestHelper().Post<PlayBook>($"api/PlaybookManagement/CreatePlaybook", newPlayBook);
        }

        public async Task<bool> CreateUpdateTestInstall(TeamInstallDTO teamInstall)
        {
            return await new RestHelper().Post("api/TeamManagement/CreateTeamInstall", teamInstall);
        }

        public async Task<bool> InsertInstallPlay(string teamId, string playId)
        {
            return await new RestHelper().Get($"api/TeamManagement/InsertInstallPlay?id={teamId}&playId={playId}");
        }

        public async Task<bool> DeletePlayById(string id)
        {
            return await new RestHelper().Get($"api/PlaybookManagement/DeletePlayById?id={id}");
        }
        public async Task<bool> DeleteInstallPlay(string id, string playId)
        {
            return await new RestHelper().Get($"api/TeamManagement/DeleteInstallPlay?id={id}&playId={playId}");
        }

        public async Task<bool> SendInstallNotification(EmailDTO email)
        {
            return await new RestHelper().Post("email", email);
        }


        public async Task<bool> SavePlay(Play play)
        {
            return await new RestHelper().Post($"api/PlaybookManagement/CreatePlay", play);
        }

        public async Task<string> UploadPreview(string teamName, string playId, string fileName, byte[] fileBytes, int contentLength, string parameterName, string contentType)
        {
            return await new RestHelper().Upload($"api/PlaybookManagement/UploadPreviewFiles?teamName={teamName}&playId={playId}", fileName, fileBytes, contentLength, parameterName, contentType);
        }

        public async Task<string> UploadFile(string teamName, string playId, string fileName, byte[] fileBytes, int contentLength, string parameterName, string contentType)
        {
            return await new RestHelper().Upload($"api/PlaybookManagement/UploadFiles?teamName={teamName}&playId={playId}", fileName, fileBytes, contentLength, parameterName, contentType);
        }
    }
}