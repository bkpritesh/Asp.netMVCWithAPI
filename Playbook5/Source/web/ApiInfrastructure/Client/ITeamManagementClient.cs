using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using web.ApiInfrastructure.ApiModels;

namespace web.ApiInfrastructure.Client
{
    public interface ITeamManagementClient
    {
        Task<List<TeamApiModel>> GetAllTeams();
        Task<TeamApiModel> GetTeam(string teamId);
        Task<TeamApiModel> CreateUpdateTeam(TeamApiModel team);
        Task<List<TeamUserApiModel>> GetAllUsersByTeamId(string teamId);
        Task<List<PlaysApiModel>> GetAllPlaysByTeamId(string teamId);
        Task<List<PlayBookApiModel>> GetAllPlaybooksByTeamId(string teamId);
        Task<TeamInstallApiModel> GetTeamInstallByTeamId(string teamId);
    }
}