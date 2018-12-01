using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using web.ApiInfrastructure.Client;
using web.Areas.Management.Models.TeamManagement;

namespace web.Areas.Management.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            UserModel = new List<User>();
            User = new User();
            Team = new Team();
            Roles = new List<SelectListItem>();
            UserHistory = new List<UserHistory>();
            UserData = new List<UserData>();
        }

        public List<User> UserModel { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public List<UserHistory> UserHistory { get; set; }
        public List<UserData> UserData { get; set; }

        public async Task<User> GetUserById(string userId)
        {
            return await new RestHelper().Get<User>($"api/TeamManagement/GetUserById?id={userId}");
        }

        public async Task<Team> GetTeamByTeamId(string teamId)
        {
            return await new TeamViewModel().GetTeam(teamId);
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await new RestHelper().Get<List<Role>>($"api/Account/GetAllRoles");
        }

        public async Task Load(string userId = "", string teamId = "")
        {
            var roles = await GetAllRoles();
            Roles = roles.Select(x => new SelectListItem
            {
                Value = x.Id,
                Text = x.Name
            }).ToList();

            if (!string.IsNullOrEmpty(userId) && userId != "-1")
            {
                User = await GetUserById(userId);
                User.TeamId = teamId;
                UserHistory = await GetUserHistory(userId);
                UserData = await GetUserData(userId);
                User.UserRole = User.Roles.FirstOrDefault();
                if (User.Roles.FirstOrDefault() != null)
                {
                    var role = roles.FirstOrDefault(x => x.Name == User.Roles.FirstOrDefault());
                    User.UserRoleId = role.Id;
                }
            }
            if (!string.IsNullOrEmpty(teamId) && teamId != "-1")
            {
                Team = await GetTeamByTeamId(teamId);
            }
        }

        public async Task<List<UserHistory>> GetUserHistory(string userId)
        {
            return await new RestHelper().Get<List<UserHistory>>($"api/TeamManagement/GetUserHistoryByUserId?userId={userId}");
        }

        public async Task<List<UserData>> GetUserData(string userId)
        {
            return await new RestHelper().Get<List<UserData>>($"api/TeamManagement/GetUserDataByUserId?userId={userId}");
        }

        public async Task<bool> CreateUser(User user)
        {
            return await new RestHelper().Post($"api/Account/CreateUser", user);
        }
    }
}