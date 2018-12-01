using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web.ApiInfrastructure.Client;
using web.Areas.Management.Models.TeamManagement;

namespace web.Areas.Management.ViewModels
{
    public class PlayViewModel
    {
        public PlayViewModel()
        {
            Plays = new List<Play>();
            Playbooks = new List<PlayBook>();
            TeamInstall = new TeamInstall();
            TeamNotes = new TeamNoteList();
            TeamUsers = new List<TeamUser>();
        }

        public async Task Load(string teamId)
        {
            if (!string.IsNullOrEmpty(teamId))
            {
                Plays = await GetAllPlaysByTeamId(teamId);
                Playbooks = await GetAllPlaybooksByTeamId(teamId);
                TeamInstall = await GetAllTeamInstalledByTeamId(teamId);
                TeamNotes = await GetAllTeamNotesByTeamId(teamId);
                TeamUsers = await GetUsersByTeamId(teamId);
                TeamId = teamId;
            }
        }

        public string TeamId { get; set; }
        public List<Play> Plays { get; set; }
        public List<PlayBook> Playbooks { get; set; }
        public TeamInstall TeamInstall { get; set; }
        public TeamNoteList TeamNotes { get; set; }
        public List<TeamUser> TeamUsers { get; set; }
        

        public async Task<List<Play>> GetAllPlaysByTeamId(string teamId)
        {
            return await new RestHelper().Get<List<Play>>($"api/PlaybookManagement/GetAllPlaysByTeamId?teamid={teamId}");
        }

        public async Task<TeamNoteList> GetAllTeamNotesByTeamId(string teamId)
        {
            return await new RestHelper().Get<TeamNoteList>($"api/TeamNotes/GetAllTeamNotesByTeamId?teamid={teamId}");
        }

        public async Task<List<PlayBook>> GetAllPlaybooksByTeamId(string teamId)
        {
            return await new RestHelper().Get<List<PlayBook>>($"api/PlaybookManagement/GetAllPlaybooksByTeamId?teamid={teamId}");
        }

        public async Task<TeamInstall> GetAllTeamInstalledByTeamId(string teamId)
        {
            return await new RestHelper().Get<TeamInstall>($"api/TeamManagement/TeamInstallsByIdGet/{teamId}");
        }
        
        public async Task<bool> CreateUpdateTestInstall(TeamInstallDTO teamInstall)
        {
            return await new RestHelper().Post("api/TeamManagement/CreateTeamInstall", teamInstall);
        }

        public async Task<bool> InsertInstallPlay(string teamId, string playId)
        {
            return await new RestHelper().Get($"api/TeamManagement/InsertInstallPlay?id={teamId}&playId={playId}");
        }


        public async Task<bool> DeleteTeamNotesById(string id)
        {
            return await new RestHelper().Get($"api/TeamNotes/DeleteTeamNotesById?id={id}");
        }

        public async Task<bool> DeletePlayById(string id)
        {
            return await new RestHelper().Get($"api/PlaybookManagement/DeletePlayById?id={id}");
        }
        public async Task<bool> DeleteInstallPlay(string id, string playId)
        {
            return await new RestHelper().Get($"api/TeamManagement/DeleteInstallPlay?id={id}&playId={playId}");
        }

        public async Task<bool> SavePlay(Play play)
        {
            return await new RestHelper().Post($"api/PlaybookManagement/CreatePlay", play);
        }

        public async Task<bool> CreateTeamNotes(TeamNote teamNote)
        {
            return await new RestHelper().Post($"api/TeamNotes/CreateTeamNotes", teamNote);
        }

        public async Task<string> UploadPreview(string teamName, string playId, string fileName, byte[] fileBytes, int contentLength, string parameterName, string contentType)
        {
            return await new RestHelper().Upload($"api/PlaybookManagement/UploadPreviewFiles?teamName={teamName}&playId={playId}", fileName, fileBytes, contentLength, parameterName, contentType);
        }

        public async Task<string> UploadFile(string teamName, string playId, string fileName, byte[] fileBytes, int contentLength, string parameterName, string contentType)
        {
            return await new RestHelper().Upload($"api/PlaybookManagement/UploadFiles?teamName={teamName}&playId={playId}", fileName, fileBytes, contentLength, parameterName, contentType);
        }

        public async Task<List<TeamUser>> GetUsersByTeamId(string teamId)
        {
            return await new RestHelper().Get<List<TeamUser>>($"api/TeamManagement/GetAllUsersByTeamId?teamid={teamId}");
        }
    }
}