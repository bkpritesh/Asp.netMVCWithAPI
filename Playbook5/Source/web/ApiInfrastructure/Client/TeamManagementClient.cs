using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web.ApiHelper.Client;
using web.ApiHelper.Response;
using web.ApiInfrastructure.ApiModels;
using web.ApiInfrastructure.Responses;
using web.Models;

namespace web.ApiInfrastructure.Client
{
    public class TeamManagementClient : ClientBase, ITeamManagementClient
    {
        private static readonly string BaseUrl = AppConst.WebApiUrl;
        private static readonly string TokenUri = BaseUrl.Replace("/api", "/") + "token";
        private static readonly string RegisterUri = BaseUrl + "register/Post";
        private static readonly string AllTeamsUri = BaseUrl + "/TeamManagement/GetAllTeams";
        private static readonly string TeamUri = BaseUrl + "/TeamManagement/GetTeam?Id={0}";
        private static readonly string CreateUpdateTeamUri = BaseUrl + "/TeamManagement/CreateTeam";
        private static readonly string AllUsersByTeamUri = BaseUrl + "/TeamManagement/GetAllUsersByTeamId?TeamId={0}";
        private static readonly string AllPlaysByTeamUri = BaseUrl + "/PlaybookManagement/GetAllPlaysByTeamId?TeamId={0}";
        private static readonly string AllPlaybooksByTeamUri = BaseUrl + "/PlaybookManagement/GetAllPlaybooksByTeamId?TeamId={0}";
        private static readonly string TeamInstallByTeamUri = BaseUrl + "/TeamManagement/TeamInstallsByIdGet/{0}";

        public TeamManagementClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<List<TeamApiModel>> GetAllTeams()
        {
            var response = await ApiClient.GetJsonEncodedContent(AllTeamsUri);
            return await DecodeContent<List<TeamApiModel>>(response);
        }

        public async Task<TeamApiModel> GetTeam(string teamId)
        {
            var response = await ApiClient.GetJsonEncodedContent(string.Format(TeamUri, teamId));
            return await DecodeContent<TeamApiModel>(response);
        }

        public async Task<TeamApiModel> CreateUpdateTeam(TeamApiModel team)
        {
            var response = await ApiClient.PostJsonEncodedContent(CreateUpdateTeamUri, team);
            return await DecodeContent<TeamApiModel>(response);
        }

        public async Task<List<TeamUserApiModel>> GetAllUsersByTeamId(string teamId)
        {
            var response = await ApiClient.GetJsonEncodedContent(string.Format(AllUsersByTeamUri, teamId));
            return await DecodeContent<List<TeamUserApiModel>>(response);
        }

        public async Task<List<PlaysApiModel>> GetAllPlaysByTeamId(string teamId)
        {
            var response = await ApiClient.GetJsonEncodedContent(string.Format(AllPlaysByTeamUri, teamId));
            return await DecodeContent<List<PlaysApiModel>>(response);
        }

        public async Task<List<PlayBookApiModel>> GetAllPlaybooksByTeamId(string teamId)
        {
            var response = await ApiClient.GetJsonEncodedContent(string.Format(AllPlaybooksByTeamUri, teamId));
            return await DecodeContent<List<PlayBookApiModel>>(response);
        }

        public async Task<TeamInstallApiModel> GetTeamInstallByTeamId(string teamId)
        {
            var response = await ApiClient.GetJsonEncodedContent(string.Format(TeamInstallByTeamUri, teamId));
            return await DecodeContent<TeamInstallApiModel>(response);
            
        }
    }
}