using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web.ApiInfrastructure.ApiModels;
using web.ApiInfrastructure.Client;
using web.Areas.Management.Models.Reporting;

namespace web.Areas.Management.ViewModels
{
    public class InstallPlayViewModel
    {
        public List<UserData> UserData { get; set; }
        public Play Play { get; set; }
        public InstallPlayViewModel()
        {
            UserData = new List<UserData>();
            Play = new Play();
        }
        public async Task Load(string playId)
        {
            UserData = await GetUserDataByPlayId(playId);
            Play = await GetPlayById(playId);
            Play.PlayId = playId;
        }

        public async Task<List<UserData>> GetUserDataByPlayId(string playId)
        {
            return await new RestHelper().Get<List<UserData>>("api/TeamManagement/GetUserDataByPlayId?playId=" + playId);
        }

        public async Task<Play> GetPlayById(string playId)
        {
            return await new RestHelper().Get<Play>("api/PlaybookManagement/GetPlayById?id=" + playId);
        }
    }
}